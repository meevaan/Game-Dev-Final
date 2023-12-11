using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalStats : MonoBehaviour
{
    public TMP_Text completeTime;
    public float secs;
    public float Mins;
    public TMP_Text RoomsCleared;
    public TMP_Text EnemiesKilled;
    public TMP_Text OverallScore;
    public Button MenuButton;

    public GameObject Player;
    public PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        stats = Player.GetComponent<PlayerStats>();

        Button button = MenuButton.GetComponent<Button>();
        button.onClick.AddListener(LoadMenu);
    }

    // Update is called once per frame
    void Update()
    {
        completeTime.text = "Time: "+stats.MinsLeft.ToString()+":"+Mathf.Round(stats.TimeLeft).ToString();
        RoomsCleared.text = "Rooms Cleared: "+stats.RoomsCleared.ToString();
        EnemiesKilled.text = "Enemies Killed "+stats.EnemiesKilled.ToString();
        OverallScore.text = "Score: "+stats.PlayerScore.ToString();
    }

    void LoadMenu()
    {
        Destroy(Player);
        SceneManager.LoadScene("MainMenu");
    }
}
