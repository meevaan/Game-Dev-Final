using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool ButtonPressed;

    public bool CanPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && CanPress == true)
        {
            //GameObject.Find("Player").GetComponent<PlayerStats>().PlayerScore += 35;
            ButtonPressed = true;
        }
        if(ButtonPressed == true)
        {
            this.GetComponent<Collider>().enabled = false;
            if(this.transform.localPosition.z >= 2.48f && this.transform.localPosition.z <= 3f)
            {
                this.transform.localPosition += new Vector3 (0f, 0f, 0.01f);
            }
        }
        if(ButtonPressed == false)
        {
            this.GetComponent<Collider>().enabled = true;
            if(this.transform.localPosition.z > 2.48f && this.transform.localPosition.z > -1.86f)
            {
                this.transform.localPosition += new Vector3 (0f, 0f, -0.01f);
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CanPress = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CanPress = false;
        }
    }
}
