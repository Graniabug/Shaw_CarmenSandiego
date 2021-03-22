/*************************************************************************************************************************
 * Name: ResearchBehavior
 * Description: Controls the research mechanics and UI
 * Attached to: 
 *      Scene: SampleScene
 *      Object: ResearchText
 * Created By: Kayleigh Shaw
 * Created On: 3/15/2021
 * 
 * Last Edit: Add comments
 * Last Edited By: Kayleigh Shaw
 * Last Edited On: 3/17/2021
 * ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBehavior : MonoBehaviour
{
    private bool option1Correct = false;  //true if the selected option in dropdown 1 is correct
    private bool option2Correct = false;  //true if the selected option in dropdown 2 is correct
    private bool option3Correct = false;  //true if the selected option in dropdown 3 is correct

    public Dropdown dropdown1;  //a reference to the dropdown1 object
    public Dropdown dropdown2;  //a reference to the dropdown2 object
    public Dropdown dropdown3;  //a reference to the dropdown3 object
    public EventContainer currentEvent;  //a reference to the current event
    public Text dialogue;  //a reference to the "console" object to which all dialogue is printed

    /**************************************************
    * Name: Update
    * Description: If all the options have been set 
    * correctly, print info text and tell the EventManager 
    * that the creature has been found
    * Original Author: Kayleigh Shaw
    * Precondition: called once per frame
    * ************************************************/
    void Update()
    {
        //If all the options have been set correctly...
        if (option1Correct && option2Correct && option3Correct && !currentEvent.creatureFound)
        {
            //print info text...
            dialogue.text = "Oh!  It looks like you're dealing with a " + currentEvent.GetTextCreature();
            switch (currentEvent.GetCreature())
            {
                case 0:
                    dialogue.text += "\nCat sidhe are faeries that take the form of large black cats, sometimes with white spots on their chests.  " +
                        "Villagers used to keep watch to make sure the cat doesn’t cross the bodies of the dead before they were buried for fear it’d steal the soul of the dead. " +
                        "\nTo prevent this, they would play games to destract the cat, extigush all sources of warmth (in which the cat likes to cuddle), and even leave out milk.";
                    break;
                case 1:
                    dialogue.text += "\nCu sidhe are faeries that take the form of large black or green dogs.  They are the servants of the aes sidhe, and are known to steal new human mothers to care for faery children.  " +
                        "In some cases they are also regarded as arbiters of death, much like hellhounds or even grim reapers, as they may guide the dead to the afterlife.  " +
                        "Most terrifyingly, their howl, while it serves as a warning to all who hear it, is deadly when it is heard in threes.";
                    break;
                case 2:
                    dialogue.text += "\nAes sidhe are what people typically think of as faeries.  They are beautiful human-looking people who live underground in mounds.  " +
                        "Care must be taken to not trespass on their land or otherwise insult them, as in their anger they will retaliate.";
                    break;
                case 3:
                    dialogue.text += "\nMorrigan is the goddess of war and death.  She is a shapeshifter, seen as often as a blackbird as she is a human woman.  " +
                        "She follows death, and has been known to prophesize the deaths of men by washing his bloody clothes in the sight of those who know him.";
                    break;
                case 4:
                    dialogue.text += "\nKelpies are shapeshifting creatures seen both as handsome human men and beautiful white horses.  " +
                        "In both cases they attempt to lure children and young women into bodies of water using their beauty and, if sucessful, eat them once they've drowned.";
                    break;
            }
            dialogue.text += "\nTrack it down!";

            //and tell the EventManager that the creature has been found
            currentEvent.creatureFound = true;
        }
    }

    /**************************************************
    * Name: Option1Changed
    * Description: When the dropdown in changed, check 
    * if it's correct
    * Original Author: Kayleigh Shaw
    * Called on:  SampleScene -> DropDown1 (DropDown component)
    * ************************************************/
    public void Option1Changed()
    {
        switch (currentEvent.GetCreature())
        {
            case 0:
                if (dropdown1.value == 2)
                {
                    option1Correct = true;
                }
                break;
            case 1:
                if (dropdown1.value == 1)
                {
                    option1Correct = true;
                }
                break;
            case 2:
                if (dropdown1.value == 5)
                {
                    option1Correct = true;
                }
                break;
            case 3:
                if (dropdown1.value == 4)
                {
                    option1Correct = true;
                }
                break;
            case 4:
                if (dropdown1.value == 3)
                {
                    option1Correct = true;
                }
                break;
            default:
                dialogue.text = "That's not enough information yet.";
                break;
        }
    }

    /**************************************************
    * Name: Option2Changed
    * Description: When the dropdown in changed, check 
    * if it's correct
    * Original Author: Kayleigh Shaw
    * Called on:  SampleScene -> DropDown2 (DropDown component)
    * ************************************************/
    public void Option2Changed()
    {
        switch (currentEvent.GetCreature())
        {
            case 0:
                if (dropdown2.value == 5)
                {
                    option2Correct = true;
                }
                break;
            case 1:
                if (dropdown2.value == 3)
                {
                    option2Correct = true;
                }
                break;
            case 2:
                if (dropdown2.value == 1)
                {
                    option2Correct = true;
                }
                break;
            case 3:
                if (dropdown2.value == 4)
                {
                    option2Correct = true;
                }
                break;
            case 4:
                if (dropdown2.value == 2)
                {
                    option2Correct = true;
                }
                break;
            default:
                dialogue.text = "That's not enough information yet.";
                break;
        }
    }

    /**************************************************
    * Name: Option3Changed
    * Description: When the dropdown in changed, check 
    * if it's correct
    * Original Author: Kayleigh Shaw
    * Called on:  SampleScene -> DropDown3 (DropDown component)
    * ************************************************/
    public void Option3Changed()
    {

        switch (currentEvent.GetCreature())
        {
            case 0:
                if (dropdown3.value == 3)
                {
                    option3Correct = true;
                }
                break;
            case 1:
                if (dropdown3.value == 5)
                {
                    option3Correct = true;
                }
                break;
            case 2:
                if (dropdown3.value == 1)
                {
                    option3Correct = true;
                }
                break;
            case 3:
                if (dropdown3.value == 2)
                {
                    option3Correct = true;
                }
                break;
            case 4:
                if (dropdown3.value == 4)
                {
                    option3Correct = true;
                }
                break;
            default:
                dialogue.text = "That's not enough information yet.";
                break;
        }
    }
}
