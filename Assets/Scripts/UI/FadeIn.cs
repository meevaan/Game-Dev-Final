using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn: MonoBehaviour
{
    public Image FadeInAndOut;

    public bool fadeIn;
    public bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ffadeIn());
        FadeInAndOut = GameObject.Find("FadeIn").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn == true)
        {
            FadeInAndOut.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
        }
        if(FadeInAndOut.GetComponent<CanvasGroup>().alpha <= 0)
        {
            fadeIn = false;
        }
    }

    IEnumerator ffadeIn()
    {
        yield return new WaitForSeconds(1f);
        fadeIn = true;
    }
}
