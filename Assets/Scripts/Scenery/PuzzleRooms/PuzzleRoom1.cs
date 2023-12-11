using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleRoom1 : MonoBehaviour
{
    public List<GameObject> Buttons = new List<GameObject>();
    public List<int> ButtonOrder = new List<int> { 0, 1, 2, 3 };

    public GameObject Gate;
    public bool MoveGate;

    public bool Button1Pressed;
    public bool Button2Pressed;
    public bool Button3Pressed;
    public bool Button4Pressed;

    // Start is called before the first frame update
    void Start()
    {
        Buttons = Buttons.OrderBy(i => Random.value).ToList();
        ButtonOrder = ButtonOrder.OrderBy(i => Random.value).ToList();

        //Debug.Log(ButtonOrder[0]+" "+ButtonOrder[1]+" "+ButtonOrder[2]+" "+ButtonOrder[3]);

        for(int i = 0; i < Buttons.Count; i++)
        {
            Instantiate(Buttons[ButtonOrder[i]-1], new Vector3(
                this.transform.position.x-1.80f+(1f*i), 
                this.transform.position.y-4.67f, 
                this.transform.position.z-1.86f
            ), Quaternion.identity).transform.parent = this.transform;
        }

        Buttons[0].transform.localPosition = new Vector3(-0.25f, 3.93f, 2.48f);
        Buttons[1].transform.localPosition = new Vector3(-13.84f, 4.94f, 2.48f);
        Buttons[2].transform.localPosition = new Vector3(16.05f, 0.83f, 2.48f);
        Buttons[3].transform.localPosition = new Vector3(-11.89f, -6.16f, 2.48f);
    }

    // Update is called once per frame
    void Update()
    {
        Button1Pressed = Buttons[ButtonOrder[0]-1].GetComponent<ButtonPress>().ButtonPressed;
        Button2Pressed = Buttons[ButtonOrder[1]-1].GetComponent<ButtonPress>().ButtonPressed;
        Button3Pressed = Buttons[ButtonOrder[2]-1].GetComponent<ButtonPress>().ButtonPressed;
        Button4Pressed = Buttons[ButtonOrder[3]-1].GetComponent<ButtonPress>().ButtonPressed; 

        if(Button1Pressed == true)
        {
            if(Button2Pressed == true)
            {
                if(Button3Pressed == true)
                {
                    if(Button4Pressed == true && Gate.transform.localPosition.y <= -0.98f)
                    {
                        MoveGate = true;
                    }
                }
            }
        }
        if((Button1Pressed == false && Button2Pressed == true) || 
        (Button1Pressed == false && Button3Pressed == true) || 
        (Button1Pressed == false && Button4Pressed == true) ||
        (Button2Pressed == false && Button3Pressed == true) ||
        (Button2Pressed == false && Button4Pressed == true) ||
        (Button3Pressed == false && Button4Pressed == true))
        {
            Buttons[ButtonOrder[0]-1].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[1]-1].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[2]-1].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[3]-1].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[0]-1].GetComponent<ButtonPress>().CanPress = false;
            Buttons[ButtonOrder[1]-1].GetComponent<ButtonPress>().CanPress = false;
            Buttons[ButtonOrder[2]-1].GetComponent<ButtonPress>().CanPress = false;
            Buttons[ButtonOrder[3]-1].GetComponent<ButtonPress>().CanPress = false;
            MoveGate = false;
        }

        if(MoveGate == true)
        {
            Gate.transform.position += new Vector3(0f, 0.3f, 0f);
        }
        if(Gate.transform.localPosition.y >= -0.98f)
        {
            MoveGate = false;
        }
    }
}
