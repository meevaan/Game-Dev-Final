using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject Player;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(ps, new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z), Quaternion.identity);
            Player.GetComponent<PlayerStats>().PlayerScore += 25;
            Player.GetComponent<PlayerStats>().EnemiesKilled += 1;
            Player.GetComponent<PlayerStats>().PlayerHealth += 25f;
            Player.GetComponent<SpawnAttack>().attacksAmount += 1;
            Destroy(this.gameObject);
        }
    }
}
