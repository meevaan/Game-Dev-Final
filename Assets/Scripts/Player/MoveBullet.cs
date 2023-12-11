using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    Rigidbody bullet;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        bullet = this.GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");

        if(Player.transform.eulerAngles.y == 90f)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        if(Player.transform.eulerAngles.y == 270f)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bullet.AddForce(transform.up * 15f, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= 100f;
        }
        if(collision.gameObject.tag != "Player" || collision.gameObject.tag != "Weapon")
        {
            Destroy(this.gameObject);
        }
    }
}
