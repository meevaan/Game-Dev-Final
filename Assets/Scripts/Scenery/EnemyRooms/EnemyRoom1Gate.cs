using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom1Gate : MonoBehaviour
{
    public bool MoveGate;

    public List<GameObject> Enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies.Count > 0)
        {
            MoveGate = false;
            this.transform.localPosition = new Vector3(18.0699959f, -6.39157104f, 1.622612f);
            
            for(int i = 0; i < Enemies.Count; i++)
            {
                if(Enemies[i] == null)
                {
                    Enemies.RemoveAt(i);
                }
            }
        }

        if(Enemies.Count == 0 && this.transform.localPosition.y <= -0.98f)
        {
            MoveGate = true;
        }
        if(MoveGate == true)
        {
            this.transform.position += new Vector3(0f, 0.3f, 0f);
        }
        if(this.transform.localPosition.y >= -0.98f)
        {
            MoveGate = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(!Enemies.Contains(collision.gameObject) && collision.gameObject.tag == "Enemy")
        {
            Enemies.Add(collision.gameObject);
        }
    }
}