using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcNothingBehavior : StateMachineBehaviour
{
    public Text dialogue;
    public int location;
    public EventContainer currentEvent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentEvent = GameObject.Find("Canvas").GetComponent<EventContainer>();
        dialogue = GameObject.Find("ConsoleText").GetComponent<Text>();
        dialogue.text = "I'm afraid I don't know anything about that...";
        int locationIndex = currentEvent.GetLocation();
        /*if (location == locationIndex)
        {
            animator.SetInteger("proximity", 0);
        }
        else if (location == (locationIndex + 1) || location == (locationIndex - 1))
        {
            animator.SetInteger("proximity", 1);
        }
        else
        {
            animator.SetInteger("proximity", 2);
        }*/
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
