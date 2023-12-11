using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float PlayerHealth;
    public int PlayerScore;

    public bool Decrease;

    public TMP_Text Score;
    public TMP_Text Health;

    public float TimeLeft;
    public float MinsLeft;
    public int EnemiesKilled;
    public int RoomsCleared;

    Animator PlayerAnim;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 200f;
        Decrease = true;

        DontDestroyOnLoad(this.gameObject);

        PlayerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Score = GameObject.Find("Score").GetComponent<TMP_Text>();
        Health = GameObject.Find("Health").GetComponent<TMP_Text>();

        Health.text = "Health: "+PlayerHealth;

        if(Decrease == true)
        {
            StartCoroutine(PlayerScoreDown());
            Decrease = false;
        }

        Score.text = "Score: "+PlayerScore;

        TimeLeft += Time.deltaTime;
        if(TimeLeft >= 60f)
        {
            MinsLeft += 1f;
            TimeLeft = 0f;
        }

        if(PlayerHealth <= 0f)
        {
            StartCoroutine(Death());
        }
        if(PlayerHealth > 200f)
        {
            PlayerHealth = 200f;
        }
    }

    IEnumerator PlayerScoreDown()
    {
        PlayerScore -= 1;
        yield return new WaitForSeconds(1f);
        Decrease = true;
    }

    IEnumerator Death()
    {
        PlayerAnim.Play("Dead00");
        this.GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyWeapon")
        {
            PlayerHealth -= 10f;
        }
    }
}
