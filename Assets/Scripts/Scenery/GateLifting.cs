using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLifting : MonoBehaviour
{
    public bool MoveGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveGate == true)
        {
            this.transform.position += new Vector3(0f, 0.3f, 0f);
        }
        if(this.transform.localPosition.y >= 4.43f)
        {
            MoveGate = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           MoveGate = true;
        }
    }
}
