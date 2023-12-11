using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBulletImage : MonoBehaviour
{
    public Image bulletImage;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount < Player.GetComponent<SpawnAttack>().attacksAmount/3)
        {
            Instantiate(bulletImage, this.transform);
        }
        if(this.transform.childCount > Player.GetComponent<SpawnAttack>().attacksAmount/3)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
    }
}
