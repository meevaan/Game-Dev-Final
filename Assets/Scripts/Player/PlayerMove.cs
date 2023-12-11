using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody Player;
    Animator PlayerAnim;

    public int AttackCounter;

    public bool Jumping;
    public bool Falling;

    public AudioSource swingSound;
    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<Rigidbody>();
        PlayerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            //this.transform.position += new Vector3(0.20f, 0f, 0f);
            Player.AddForce(transform.forward * 1250f, ForceMode.Force);

            this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }

        if(Input.GetKey(KeyCode.A))
        {
            Player.AddForce(transform.forward * 1250f, ForceMode.Force);
            //this.transform.position -= new Vector3(0.20f, 0f, 0f);
            this.transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }

        if(Player.velocity.x > 1.5f && Input.GetKey(KeyCode.D))
        {
            Player.velocity = new Vector3(1.5f, Player.velocity.y, Player.velocity.z);
        }
        if(Player.velocity.x < -1.5f && Input.GetKey(KeyCode.A))
        {
            Player.velocity = new Vector3(-1.5f, Player.velocity.y, Player.velocity.z);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            PlayerAnim.SetBool("Running", true);
        }
        else 
        {
            PlayerAnim.SetBool("Running", false);
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnim.Play("Idle");
        }

        if(Input.GetMouseButtonDown(0))
        {
            swingSound.Play(0);
            
            if(AttackCounter == 0)
            {
                PlayerAnim.Play("Attack00");
                AttackCounter += 1;
            }
            if(AttackCounter == 1)
            {
                PlayerAnim.Play("Attack01");
                AttackCounter = 0;
            }
        }

        if(Jumping == true)
        {
            Player.AddForce(transform.up * 40f, ForceMode.Impulse);
            Falling = true;
            Jumping = false;
        }
        if(Falling == true)
        {
            Player.AddForce(-transform.up * 30f, ForceMode.Acceleration);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Falling = false;
                Jumping = true;
                //StartCoroutine(Jump());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Camera.main.transform.position = new Vector3(collision.gameObject.transform.position.x-2f, 7.6f, -11f);
        }
    }

    /*IEnumerator Jump()
    {
        Player.AddForce(transform.up * 10f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.3f);
        Player.AddForce(-transform.up * 15f, ForceMode.Impulse);
    }*/
}
