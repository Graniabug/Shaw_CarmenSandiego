using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcLocationBehavior : StateMachineBehaviour
{
    public Text dialogue;
    public EventContainer currentEvent;
    public string[,] couldSay = new string[5, 5];

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PopulateDialogueOptions();
        currentEvent = GameObject.Find("Canvas").GetComponent<EventContainer>();
        dialogue = GameObject.Find("ConsoleText").GetComponent<Text>();
        dialogue.text = couldSay[currentEvent.GetCreature(), Random.Range(0, 5)];
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    private void PopulateDialogueOptions()
    {
        for (int a = 0; a < 5; a++)
        {
            couldSay[0, a] = ("woods option " + a);
        }

        for (int b = 0; b < 5; b++)
        {
            couldSay[1, b] = "town square option " + b;
        }

        for (int c = 0; c < 5; c++)
        {
            couldSay[2, c] = "lake option " + c;
        }

        for (int d = 0; d < 5; d++)
        {
            couldSay[3, d] = "faery circle option " + d;
        }

        for (int e = 0; e < 5; e++)
        {
            couldSay[4, e] = "graveyard option " + e;
        }
    }
}
