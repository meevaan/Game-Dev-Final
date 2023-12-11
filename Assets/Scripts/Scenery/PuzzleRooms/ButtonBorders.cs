using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBorders : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(button.transform.position.x, button.transform.position.y, 2.5f);
    }
}
