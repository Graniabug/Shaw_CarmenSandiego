using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBehavior : MonoBehaviour
{
    private bool option1Correct = false;
    private bool option2Correct = false;
    private bool option3Correct = false;
    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;

    public EventContainer currentEvent;
    public Text dialogue;
    // Start is called before the first frame update
    void Start()
    {
        //currentEvent = GameObject.Find("Canvas").GetComponent<EventContainer>();
        //dialogue = GameObject.Find("ConsoleText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (option1Correct && option2Correct && option3Correct)
        {
            dialogue.text = "Oh!  It looks like you're dealing with a " + currentEvent.GetTextCreature() + ".  Track it down!";
        }
    }

    public void Option1Changed()
    {
        if (dropdown1.value == currentEvent.GetCreature())
        {
            option1Correct = true;
        }
        else
        {
            dialogue.text = "That's not enough information yet.";
        }
    }

    public void Option2Changed()
    {
        if (dropdown2.value == currentEvent.GetCreature())
        {
            option2Correct = true;
        }
        else
        {
            dialogue.text = "That's not enough information yet.";
        }
    }

    public void Option3Changed()
    {
        if (dropdown3.value == currentEvent.GetCreature())
        {
            option3Correct = true;
        }
        else
        {
            dialogue.text = "That's not enough information yet.";
        }
    }
}
