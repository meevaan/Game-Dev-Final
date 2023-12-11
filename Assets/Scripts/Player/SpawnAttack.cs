using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAttack : MonoBehaviour
{
    public GameObject bullet;
    public int attacksAmount;

    public bool canLaunch;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(attacksAmount >= 3)
        {
            canLaunch = true;
        }
        else
        {
            canLaunch = false;
        }

        if(Input.GetMouseButtonDown(1) && canLaunch == true)
        {
            attacksAmount -= 3;

            if(this.transform.eulerAngles.y == 90f)
            {
                Instantiate(bullet, new Vector3(this.transform.position.x+2f, this.transform.position.y+1f, this.transform.position.z), Quaternion.identity);
            }
            if(this.transform.eulerAngles.y == 270f)
            {
                Instantiate(bullet, new Vector3(this.transform.position.x-2f, this.transform.position.y+1f, this.transform.position.z), Quaternion.identity);
            }
        }

        if(attacksAmount > 12)
        {
            attacksAmount = 12;
        }
    }
}
