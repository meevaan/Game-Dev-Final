using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuScore : MonoBehaviour
{
    public int AllTimeHighScore;

    public int PlayersActiveScore;

    public TMP_Text MenuHighScore;

    static MainMenuScore instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
		{	
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            PlayersActiveScore = GameObject.Find("Player").GetComponent<PlayerStats>().PlayerScore;
        }

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            MenuHighScore = GameObject.Find("AllTimeHighScore").GetComponent<TMP_Text>();
        }

        if(MenuHighScore != null)
        {
            if(PlayersActiveScore > AllTimeHighScore)
            {
                AllTimeHighScore = PlayersActiveScore;
            }

            MenuHighScore.text = "Highscore: "+AllTimeHighScore.ToString();
        }
    }
}
