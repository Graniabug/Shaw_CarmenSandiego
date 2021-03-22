/*************************************************************************************************************************
 * Name: NpcNothingBehavior
 * Description: Dictates what NPCs say if they have been talked to and know nothing about the event
 * Attached to: 
 *      Animator: NPCStates
 *      Object: Knows Nothing
 * Created By: Kayleigh Shaw
 * Created On: 3/10/2021
 * 
 * Last Edit: Cleaned out excess code
 * Last Edited By: Kayleigh Shaw
 * Last Edited On: 3/17/2021
 * ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcNothingBehavior : StateMachineBehaviour
{
    public Text dialogue;  //reference to the console object to which dialogue prints
    public EventContainer currentEvent;  //reference to the container object for the current event

    /**************************************************
    * Name: OnStateEnter
    * Description: NPC says that they don't know anything
    * Original Author: Kayleigh Shaw
    * Inputs: Animator animator, AnimatorStateInfo stateInfo, int layerIndex
    * Precondition: called when a transition starts 
    * and the state machine starts to evaluate this state
    * ************************************************/
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get objects
        currentEvent = GameObject.Find("Canvas").GetComponent<EventContainer>();
        dialogue = GameObject.Find("ConsoleText").GetComponent<Text>();

        //print text
        dialogue.text = "I'm afraid I don't know anything about that...";
        //int locationIndex = currentEvent.GetLocation();
    }
}
