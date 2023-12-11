using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedRoom : MonoBehaviour
{
    public bool clearedRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" && clearedRoom == false)
        {
            GameObject.Find("Player").GetComponent<PlayerStats>().PlayerScore += 100;
            GameObject.Find("Player").GetComponent<PlayerStats>().RoomsCleared += 1;
            clearedRoom = true;
        }
    }
}
