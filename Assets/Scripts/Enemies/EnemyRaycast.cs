using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    Ray forwardRay;
    Ray backwardRay;
    Rigidbody enemy;

    public bool MoveToPlayer;
    public bool NearPlayer;

    Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponent<Rigidbody>();
        enemyAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forwardRay = new Ray(transform.position, transform.forward);
        backwardRay = new Ray(transform.position, -transform.forward);

        if(Physics.Raycast(forwardRay, out RaycastHit forwardHit))
        {
            //Debug.Log(forwardHit.distance);

            if(forwardHit.transform.tag == "Player" && NearPlayer == false && forwardHit.distance < 10f)
            {
                MoveToPlayer = true;
            }
            if(forwardHit.transform.tag != "Player")
            {
                MoveToPlayer = false;
                enemyAnim.Play("infantry_01_idle");
            }
        }
        if(Physics.Raycast(backwardRay, out RaycastHit backwardHit))
        {
            if(backwardHit.transform.tag == "Player")
            {
                this.transform.eulerAngles += new Vector3(0f, 180f, 0f);
            }
        }

        if(MoveToPlayer == true)
        {
            enemy.AddForce(transform.forward * 500f, ForceMode.Force);
        }

        if(NearPlayer == false && MoveToPlayer == true)
        {
            enemyAnim.Play("infantry_03_run_rm");
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            NearPlayer = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            NearPlayer = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            enemy.AddForce(-transform.up * 50f, ForceMode.Impulse);
        }
    }
}
