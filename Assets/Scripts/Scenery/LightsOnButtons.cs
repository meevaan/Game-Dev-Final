using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOnButtons : MonoBehaviour
{
    public GameObject LightToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(LightToFollow.transform.position.x, LightToFollow.transform.position.y, LightToFollow.transform.position.z-3f);
    }
}
