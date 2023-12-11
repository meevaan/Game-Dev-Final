using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    Animator enemyAnim;
    public float attackTimer;
    public Collider swordCollider;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = this.GetComponent<Animator>();
        swordCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(attackTimer >= 2f)
        {
            enemyAnim.Play("infantry_04_attack_A");
            attackTimer = 0f;
        }

        if(this.enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("infantry_04_attack_A"))
        {
            swordCollider.enabled = true;
        }
        else
        {
            swordCollider.enabled = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyAnim.Play("infantry_04_attack_A");
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attackTimer += Time.deltaTime;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyAnim.SetBool("AttackPlayer", false);
            attackTimer = 0f;
        }
    }
}
