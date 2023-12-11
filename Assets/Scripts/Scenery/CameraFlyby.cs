using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlyby : MonoBehaviour
{
    public bool flyby;
    public GameObject exitRoom;
    public Vector3 startPos;

    public GameObject playerBarrier;
    public Vector3 barrierPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cameraFlyBy());
        barrierPos = playerBarrier.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(flyby == true)
        {
            this.transform.position -= new Vector3(0.2f, 0f, 0f);
            playerBarrier.transform.position = barrierPos;
        }
        if(this.transform.position.x < startPos.x)
        {
            this.transform.position = new Vector3(0f, 7.6f, -11f);
            flyby = false;
            playerBarrier.transform.position = new Vector3(barrierPos.x, barrierPos.y+15f, barrierPos.z);
        }
    }

    IEnumerator cameraFlyBy()
    {
        yield return new WaitForSeconds(0.25f);
        startPos = this.transform.position;
        yield return new WaitForSeconds(0.25f);
        exitRoom = GameObject.Find("ExitRoom(Clone)");
        this.transform.position = new Vector3(exitRoom.transform.position.x-2f, 7.6f, -11f);
        flyby = true;
    }
}
