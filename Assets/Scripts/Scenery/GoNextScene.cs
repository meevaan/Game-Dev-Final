using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoNextScene : MonoBehaviour
{
    public Collider Barrier;
    public GameObject FadeOut;

    public bool Fade;
    public GameObject FinalStats;
    public GameObject Canvas;

    public bool spawnStats;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut = GameObject.Find("FadeIn");
        Canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(Fade == true)
        {
            FadeOut.GetComponent<CanvasGroup>().alpha += Time.deltaTime;

            if(FadeOut.GetComponent<CanvasGroup>().alpha >= 1f)
            {
                if(SceneManager.GetActiveScene().name == "Level1")
                {
                    GameObject.Find("Player").transform.position = new Vector3(-3.45000005f,-1.55999994f,-0.129999995f);
                    SceneManager.LoadScene("Level2");
                }
                if(SceneManager.GetActiveScene().name == "Level2")
                {
                    GameObject.Find("Player").transform.position = new Vector3(-3.45000005f,-1.55999994f,-0.129999995f);
                    SceneManager.LoadScene("Level3");
                }
                if(SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "Tutorial")
                {
                    //GameObject.Find("Player").transform.position = new Vector3(-1.49f,-1.56f,-0.7f);
                    //SceneManager.LoadScene("Level3");
                    Time.timeScale = 0f;
                    if(spawnStats == false)
                    {
                        Instantiate(FinalStats, Canvas.transform);
                        spawnStats = true;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Barrier.enabled = true;
            Fade = true;
        }
    }
}
