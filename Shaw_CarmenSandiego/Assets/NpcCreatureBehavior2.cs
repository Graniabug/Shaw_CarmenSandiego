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

public class NpcCreatureBehavior2 : StateMachineBehaviour
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
            couldSay = "Do you know if anyone around here keeps a cat?  I swear, it was massive!  It must be a brilliant mouse-catcher...";
        }

        if (currentEvent.GetCreature() == 1) //if the event was caused by a cu sidhe...
        {
            couldSay = "Can a dog have a green coat?  I certainly have never seen one like it before...";
        }

        if (currentEvent.GetCreature() == 2) //if the event was caused by a aes sidhe...
        {
            couldSay = "I saw a beautiful woman at the outskirts of town earlier.  I've never seen her around here before, I'm sure of that.";
        }

        if (currentEvent.GetCreature() == 3) //if the event was caused by Morrigan...
        {
            couldSay = "My neighbor came back early yesterday claiming she'd seen an unfamiliar woman carrying a basket of bloodied clothing!  It must of been a ghost!";
        }

        if (currentEvent.GetCreature() == 4) //if the event was caused by a kelpie...
        {
            couldSay = "When I opened my door this morning, there was a drenched track running right through town.  There were some water weeds in it, too.";
        }
    }
}
