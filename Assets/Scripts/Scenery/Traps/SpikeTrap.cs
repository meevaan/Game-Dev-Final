using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Vector3 StartPos;
    public Rigidbody Spikes;
    public float MaxDistanceAway;
    public float SpikeCycle;
    public Collider boxCol;

    public bool FacingLeft;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.position;
        Spikes = this.GetComponent<Rigidbody>();
        boxCol = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        SpikeCycle += Time.deltaTime;

        if(this.transform.localEulerAngles.y >= 180f)
        {
            FacingLeft = true;
        }

        if(FacingLeft == false)
        {
            if(SpikeCycle >= 5f)
            {
                Spikes.AddForce(transform.right * 250, ForceMode.Impulse);
                SpikeCycle = 0f;
                boxCol.enabled = true;
            }
            if(this.transform.position.x >= StartPos.x + MaxDistanceAway)
            {
                Spikes.velocity = new Vector3(0f, 0f, 0f);
                boxCol.enabled = false;
            }
            if(this.transform.position.x >= StartPos.x)
            {
                this.transform.position -= new Vector3(0.05f, 0f, 0f);
            }
            if(this.transform.position.x <= StartPos.x)
            {
                this.transform.position = StartPos;
            }

            if(this.transform.position.x > StartPos.x)
            {
                this.GetComponent<Collider>().enabled = true;
            }
            if(this.transform.position.x <= StartPos.x)
            {
                this.GetComponent<Collider>().enabled = false;
            }
        }
        if(FacingLeft == true)
        {
            if(SpikeCycle >= 5f)
            {
                Spikes.AddForce(transform.right * 250, ForceMode.Impulse);
                SpikeCycle = 0f;
            }
            if(this.transform.position.x <= StartPos.x - MaxDistanceAway)
            {
                Spikes.velocity = new Vector3(0f, 0f, 0f);
            }
            if(this.transform.position.x <= StartPos.x)
            {
                this.transform.position += new Vector3(0.05f, 0f, 0f);
            }
            if(this.transform.position.x >= StartPos.x)
            {
                this.transform.position = StartPos;
            }

            if(this.transform.position.x < StartPos.x)
            {
                this.GetComponent<Collider>().enabled = true;
            }
            if(this.transform.position.x >= StartPos.x)
            {
                this.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
