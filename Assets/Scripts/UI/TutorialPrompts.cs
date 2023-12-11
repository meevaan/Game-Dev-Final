using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialPrompts : MonoBehaviour
{
    public TMP_Text childText;

    public bool fade;

    // Start is called before the first frame update
    void Start()
    {
        childText = this.transform.GetChild(0).GetComponent<TMP_Text>();
        childText.color = new Color(1,1,1,0);
    }

    void Update()
    {
        if(fade == true)
        {
            childText.color += new Color(0,0,0,0.005f);
        }
        if(fade == false)
        {
            childText.color -= new Color(0,0,0,0.005f);
        }

        if(childText.color.a < 1 && fade == false)
        {
            childText.color = new Color(1,1,1,0);
        }
        if(childText.color.a > 1 && fade == true)
        {
            childText.color = new Color(1,1,1,1);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fade = false;
        }
    }
        void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fade = true;
        }
    }
}
