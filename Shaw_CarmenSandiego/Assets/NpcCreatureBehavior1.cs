/*************************************************************************************************************************
 * Name: NpcCreatureBehavior
 * Description: Dictates what NPCs say if they have been talked to and they are near enough to the event to know about the creature
 * Attached to: 
 *      Animator: NPCStates
 *      Object: Knows About Creature
 * Created By: Kayleigh Shaw
 * Created On: 3/10/2021
 * 
 * Last Edit: Made NPCs say all three pieces of information instead of a random selection
 * Last Edited By: Kayleigh Shaw
 * Last Edited On: 3/22/2021
 * ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcCreatureBehavior1 : StateMachineBehaviour
{
    private Text dialogue;  //reference to the console object to which dialogue prints
    private EventContainer currentEvent;  //reference to the container object for the current event
    public string couldSay = "Empty";  //an array of things the townspeople can say, populated in PopulateDialogueOptions()

    /**************************************************
    * Name: OnStateEnter
    * Description: NPC says what they know about the creature
    * Original Author: Kayleigh Shaw
    * Inputs: Animator animator, AnimatorStateInfo stateInfo, int layerIndex
    * Precondition: called when a transition starts 
    * and the state machine starts to evaluate this state
    * ************************************************/
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get variable object references
        currentEvent = GameObject.Find("Canvas").GetComponent<EventContainer>();
        Debug.Log(currentEvent.GetTextCreature() + ", " + currentEvent.GetTextLocation());
        dialogue = GameObject.Find("ConsoleText").GetComponent<Text>();

        PopulateDialogueOptions();

        //print dialogue
        dialogue.text = couldSay;
    }

    /**************************************************
    * Name: PopulateDialogueOptions
    * Description: Fills an array with things the NPC 
    * could say based on which creature caused the 
    * current event
    * Original Author: Kayleigh Shaw
    * Called in: NpcCreatureBehavior -> OnStateEnter()
    * Precondition: OnStateEnter called
    * ************************************************/
    private void PopulateDialogueOptions()
    {
        if (currentEvent.GetCreature() == 0) //if the event was caused by a cat sidhe...
        {
            couldSay = "There was a funeral in town last night; I'm sure you're aware.  Death attracts many things.";
        }

        if (currentEvent.GetCreature() == 1) //if the event was caused by a cu sidhe...
        {
            couldSay = "I heard a single howl.  Blood-curdling, I might've died on the spot.";
        }

        if (currentEvent.GetCreature() == 2) //if the event was caused by a aes sidhe...
        {
            couldSay = "Our Good Neighbors seem displeased.  Has something happened?";
        }

        if (currentEvent.GetCreature() == 3) //if the event was caused by Morrigan...
        {
            couldSay = "I saw some blackbirds on the roofs last night.  They seemed to watch me.";
        }

        if (currentEvent.GetCreature() == 4) //if the event was caused by a kelpie...
        {
            couldSay = "A white horse with no rider trotted through town once.  My, the children cooed after it, as beautiful as it was.";
        }
    }
}
