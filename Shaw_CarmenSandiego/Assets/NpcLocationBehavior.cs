/*************************************************************************************************************************
 * Name: NpcLocationBehavior
 * Description: Dictates what NPCs say if they have been talked to and they are near enough to the event to know about the location
 * Attached to: 
 *      Animator: NPCStates
 *      Object: Knows About Location
 * Created By: Kayleigh Shaw
 * Created On: 3/10/2021
 * 
 * Last Edit: Add comments
 * Last Edited By: Kayleigh Shaw
 * Last Edited On: 3/17/2021
 * ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcLocationBehavior : StateMachineBehaviour
{
    public Text dialogue;  //reference to the console object to which dialogue prints
    public EventContainer currentEvent;  //reference to the container object for the current event
    public string[] couldSay = new string[3];  //an array of things the townspeople can say, populated in PopulateDialogueOptions()

    /**************************************************
    * Name: OnStateEnter
    * Description: NPC says what they know about the location
    * Original Author: Kayleigh Shaw
    * Inputs: Animator animator, AnimatorStateInfo stateInfo, int layerIndex
    * Precondition: called when a transition starts 
    * and the state machine starts to evaluate this state
    * ************************************************/
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get variable object references
        currentEvent = GameObject.Find("Canvas").GetComponent<EventContainer>();
        dialogue = GameObject.Find("ConsoleText").GetComponent<Text>();

        PopulateDialogueOptions();

        //print dialogue
        dialogue.text = couldSay[Random.Range(0, 3)];
    }

    /**************************************************
    * Name: PopulateDialogueOptions
    * Description: Fills an array with things the NPC 
    * could say based on which location the current event 
    * took place in
    * Original Author: Kayleigh Shaw
    * Called in: NpcLocationBehavior -> OnStateEnter()
    * Precondition: OnStateEnter called
    * ************************************************/
    private void PopulateDialogueOptions()
    {
        if (currentEvent.GetLocation() == 0) //if the event happened in the woods...
        {
            couldSay[0] = "The trees rustled earlier, I could see it from here!";
            couldSay[1] = "I heard shouts coming from the woods!";
            couldSay[2] = "I swear every bird in the woods rose up earlier!";
        }

        if (currentEvent.GetLocation() == 1) //if the event happened in the town square...
        {
            couldSay[0] = "All the shops had their doors closed, last I checked.  No clue why.";
            couldSay[1] = "I heard shouts coming from the town square!";
            couldSay[2] = "There was a crowd in town earlier.  I saw it from outside.";
        }

        if (currentEvent.GetLocation() == 2) //if the event happened at the lake...
        {
            couldSay[0] = "All the fishermen came back early today.  Very early.  Did something happen?";
            couldSay[1] = "I heard shouts coming from the lake!";
            couldSay[2] = "That lake always did give me the creeps...";
        }

        if (currentEvent.GetLocation() == 3) //if the event happened at the faery circle...
        {
            couldSay[0] = "I never really believed the superstition around a circle of mushrooms, but maybe there is something to it...";
            couldSay[1] = "I heard shouts coming from near the faery circle!";
            couldSay[2] = "The faery circle outside town has always worried me.  Guess now I have reason!";
        }

        if (currentEvent.GetLocation() == 4) //if the event happened in the graveyard...
        {
            couldSay[0] = "Ohh, how the dead must be shaking in their graves!";
            couldSay[1] = "I heard shouts coming from the graveyard!";
            couldSay[2] = "They say mysterious things happen in graveyards, but I never thought it was true...";
        }
    }
}
