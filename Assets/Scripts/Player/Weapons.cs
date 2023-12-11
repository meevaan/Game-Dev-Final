using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float weaponDamage;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Collider>().enabled = false;
        weaponDamage = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {      
            StartCoroutine(Swing());
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= weaponDamage;
        }
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.25f);
        this.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Collider>().enabled = false;
    }
}
