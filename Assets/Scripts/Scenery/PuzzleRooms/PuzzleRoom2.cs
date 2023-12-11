using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleRoom2 : MonoBehaviour
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
            Instantiate(Buttons[ButtonOrder[i]], new Vector3(
                this.transform.position.x-8.30f+(1f*i), 
                this.transform.position.y+5f, 
                this.transform.position.z-1.86f
            ), Quaternion.identity).transform.parent = this.transform;
        }

        Buttons[0].transform.localPosition = new Vector3(14.3f, 5.88f, 2.48f);
        Buttons[1].transform.localPosition = new Vector3(-12.22f, 3.49f, 2.48f);
        Buttons[2].transform.localPosition = new Vector3(2.17f, -6.8f, 2.48f);
        Buttons[3].transform.localPosition = new Vector3(8.44f, -2.9f, 2.48f);
    }

    // Update is called once per frame
    void Update()
    {
        Button1Pressed = Buttons[ButtonOrder[0]].GetComponent<ButtonPress>().ButtonPressed;
        Button2Pressed = Buttons[ButtonOrder[1]].GetComponent<ButtonPress>().ButtonPressed;
        Button3Pressed = Buttons[ButtonOrder[2]].GetComponent<ButtonPress>().ButtonPressed;
        Button4Pressed = Buttons[ButtonOrder[3]].GetComponent<ButtonPress>().ButtonPressed; 

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
            Buttons[ButtonOrder[0]].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[1]].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[2]].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[3]].GetComponent<ButtonPress>().ButtonPressed = false;
            Buttons[ButtonOrder[0]].GetComponent<ButtonPress>().CanPress = false;
            Buttons[ButtonOrder[1]].GetComponent<ButtonPress>().CanPress = false;
            Buttons[ButtonOrder[2]].GetComponent<ButtonPress>().CanPress = false;
            Buttons[ButtonOrder[3]].GetComponent<ButtonPress>().CanPress = false;
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

