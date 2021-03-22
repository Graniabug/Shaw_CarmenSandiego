/*************************************************************************************************************************
 * Name: EventManager
 * Description: Controls the events that take place in the game
 * Attached to: 
 *      Scene: SampleScene
 *      Object: Canvas
 * Created By: Kayleigh Shaw
 * Created On: 3/10/2021
 * 
 * Last Edit: Add comments
 * Last Edited By: Kayleigh Shaw
 * Last Edited On: 3/22/2021
 * ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private string startText = "The townspeople are all talking about something mysterious having happened!  Why don't you go see what it is?";  //the text that prints first when the game starts
    private int[] canGoToCurrently = new int[3];  //an array of the places which can be travelled to from where the player currently is (currently chosen at random)

    public EventContainer currentEvent;  //a reference to the object which contains info about the current event
    public Text console;  //a reference to the text object to which dialogue prints
    public Text locationText;  //A reference to a header text object which reflects the location the player is currently in
    public GameObject[] NPCs;  //an array of references to the NPC objects in the scene
    public GameObject goToButton;  //a reference to the travel button, labelled in-game as "Go to..."
    public GameObject researchButton;  //a reference to the button which allows the player to reasearch a creture based on evidence
    public GameObject researchMenu;  //a reference to the parent object of all the research menu UI
    public GameObject locationMenu;  //a reference to the parent object of all the location menu UI
    public GameObject[] buttons;  //an array of location buttons
    public GameObject playAgainButton;  //a reference to a button which reloads the scene so teh player can play again

    /**************************************************
    * Name: Start
    * Description: Sets variables to starting values and 
    * prints the starting text to the screen
    * Original Author: Kayleigh Shaw
    * Precondition: called before the first frame update
    * ************************************************/
    void Start()
    {
        int numCreatureNPCs = 0;  //contains the number of NPCs that currently know about the creature.  Should max at 2
        int creatureIndex = Random.Range(0, 4);
        int locationIndex = Random.Range(0, 4);
        currentEvent.SetEvent(creatureIndex, locationIndex);
        print(currentEvent.GetTextCreature() + ", " + currentEvent.GetTextLocation());

        for (int i = 0; i < NPCs.Length; i++)
        {
            //tell the NPCs something has happened
            NPCs[i].GetComponent<Animator>().SetBool("eventOccured", true);
            
            //set the NPC's proximity to the event and therefore sets what they know
            if (i == locationIndex || i == (locationIndex + 1) || i == (locationIndex - 1) || (locationIndex == 0 && i == (locationIndex + 2)))
            {
                print(i + ": knows about creature");
                NPCs[i].GetComponent<Animator>().SetInteger("proximity", 0);
                NPCs[i].GetComponent<Animator>().SetInteger("dialogueIndex", numCreatureNPCs);
                numCreatureNPCs++;
            }
            else if (i == (locationIndex + 2) || i == (locationIndex - 2))
            {
                print(i + ": knows about location");
                NPCs[i].GetComponent<Animator>().SetInteger("proximity", 1);
            }
            else
            {
                print(i + ": knows nothing");
                NPCs[i].GetComponent<Animator>().SetInteger("proximity", 2);
            }
        }

        //ensures the current things are visible at start
        locationMenu.SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        researchMenu.SetActive(false);
        playAgainButton.SetActive(false);

        //sets starting text
        console.text = startText;
        locationText.text = "Home";
    }

    /**************************************************
    * Name: GoToButton
    * Description: Finds which locations the player can 
    * go to and activates the travel options
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> GoToButton (Button component)
    * ************************************************/
    public void GoToButton()
    {
        //make previously active UI invisible
        goToButton.SetActive(false);
        researchButton.SetActive(false);
        for (int i = 0; i < NPCs.Length; i++)
        {
            //reset all NPCs
            NPCs[i].GetComponent<Animator>().SetBool("talkedTo", false);
        }

            //get locations that can currently be travelled to at random.
            canGoToCurrently[0] = Random.Range(0, buttons.Length);
        print(canGoToCurrently[0]);
        do
        {
            canGoToCurrently[1] = Random.Range(0, 4);
        }
        while (canGoToCurrently[1] == canGoToCurrently[0]);
        print(canGoToCurrently[1]);
        do
        {
            canGoToCurrently[2] = Random.Range(0, 4);
        }
        while ((canGoToCurrently[2] == canGoToCurrently[0]) && (canGoToCurrently[2] == canGoToCurrently[1]));
        print(canGoToCurrently[2]);

        //activate the apropriate buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
            if (i == canGoToCurrently[0] || i == canGoToCurrently[1] || i == canGoToCurrently[2])
            {
                buttons[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    /**************************************************
    * Name: ResearchButtonBehavior
    * Description: Switches from the location menu to 
    * the research menu
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> ResearchButton (Button component)
    * ************************************************/
    public void ResearchButtonBehavior()
    {
        researchMenu.SetActive(true);
        locationMenu.SetActive(false);
    }

    /**************************************************
    * Name: ResearchBackBehavior
    * Description: Switches from the research menu back to 
    * the location menu
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> ResearchButtonBack (Button component)
    * ************************************************/
    public void ResearchBackBehavior()
    {
        researchMenu.SetActive(false);
        locationMenu.SetActive(true);
    }

    /**************************************************
    * Name: WoodsButtonBehavior
    * Description: Takes the player to the woods location
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> WoodsButton (Button component)
    * ************************************************/
    public void WoodsButtonBehavior()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].SetActive(false);
        }
        goToButton.SetActive(true);
        researchButton.SetActive(true);

        NPCs[0].GetComponent<Animator>().SetBool("talkedTo", true);
        locationText.text = "The Wood";

        if (currentEvent.creatureFound && currentEvent.GetLocation() == 0)
        {
            CreatureFoundText();
            playAgainButton.SetActive(true);
            locationMenu.SetActive(false);
            for (int i = 0; i < NPCs.Length; i++)
            {
                //tell the NPCs the creature has been found
                NPCs[i].GetComponent<Animator>().SetBool("eventOccured", false);
            }
        }
    }

    /**************************************************
    * Name: SquareButtonBehavior
    * Description: Takes the player to the town square location
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> SquareButton (Button component)
    * ************************************************/
    public void SquareButtonBehavior()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].SetActive(false);
        }
        goToButton.SetActive(true);
        researchButton.SetActive(true);

        NPCs[1].GetComponent<Animator>().SetBool("talkedTo", true);
        locationText.text = "The Town Square";

        if (currentEvent.creatureFound && currentEvent.GetLocation() == 1)
        {
            CreatureFoundText();
            playAgainButton.SetActive(true);
            locationMenu.SetActive(false);
            for (int i = 0; i < NPCs.Length; i++)
            {
                //tell the NPCs the creature has been found
                NPCs[i].GetComponent<Animator>().SetBool("eventOccured", false);
            }
        }
    }

    /**************************************************
    * Name: LakeButtonBehavior
    * Description: Takes the player to the lake location
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> LakeButton (Button component)
    * ************************************************/
    public void LakeButtonBehavior()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].SetActive(false);
        }
        goToButton.SetActive(true);
        researchButton.SetActive(true);

        NPCs[2].GetComponent<Animator>().SetBool("talkedTo", true);
        locationText.text = "The Lake";

        if (currentEvent.creatureFound && currentEvent.GetLocation() == 2)
        {
            CreatureFoundText();
            playAgainButton.SetActive(true);
            locationMenu.SetActive(false);
            for (int i = 0; i < NPCs.Length; i++)
            {
                //tell the NPCs the creature has been found
                NPCs[i].GetComponent<Animator>().SetBool("eventOccured", false);
            }
        }
    }

    /**************************************************
    * Name: FaeryButtonBehavior
    * Description: Takes the player to the faery circle location
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> FaeryButton (Button component)
    * ************************************************/
    public void FaeryButtonBehavior()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].SetActive(false);
        }
        goToButton.SetActive(true);
        researchButton.SetActive(true);

        NPCs[3].GetComponent<Animator>().SetBool("talkedTo", true);
        locationText.text = "The Faery Circle";

        if (currentEvent.creatureFound && currentEvent.GetLocation() == 3)
        {
            CreatureFoundText();
            playAgainButton.SetActive(true);
            locationMenu.SetActive(false);
            for (int i = 0; i < NPCs.Length; i++)
            {
                //tell the NPCs the creature has been found
                NPCs[i].GetComponent<Animator>().SetBool("eventOccured", false);
            }
        }
    }

    /**************************************************
    * Name: GraveButtonBehavior
    * Description: Takes the player to the graveyard location
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> GraveButton (Button component)
    * ************************************************/
    public void GraveButtonBehavior()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].SetActive(false);
        }
        goToButton.SetActive(true);
        researchButton.SetActive(true);

        NPCs[4].GetComponent<Animator>().SetBool("talkedTo", true);
        locationText.text = "The Graveyard";

        if (currentEvent.creatureFound && currentEvent.GetLocation() == 4)
        {
            CreatureFoundText();
            playAgainButton.SetActive(true);
            locationMenu.SetActive(false);
            for (int i = 0; i < NPCs.Length; i++)
            {
                //tell the NPCs the creature has been found
                NPCs[i].GetComponent<Animator>().SetBool("eventOccured", false);
            }
        }
    }

    /**************************************************
    * Name: PlayAgainButtonBehavior
    *   Description: Reloads the scene so the player can play again
    * Original Author: Kayleigh Shaw
    * Called on: SampleScene -> PlayAgainButton (Button component)
    * ************************************************/
    public void PlayAgainButtonBehavior()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**************************************************
    * Name: CreatureFoundText
    * Description: Sets the end text based on current creature and location
    * Original Author: Kayleigh Shaw
    * Called in: EventManager -> _All_ButtonBehavior()
    * ************************************************/
    private void CreatureFoundText()
    {
        locationText.text = "All is as it should be...";
        console.text = "You've found the " + currentEvent.GetTextCreature() + "!";
        
        if (currentEvent.GetCreature() == 0)  //cat sidhe ending text
        {
            switch (currentEvent.GetLocation())
            {
                case 0:  //the woods
                    console.text += "  Upon seeing you, the cat dashes into the bramble.  There's no following it, but you hope you scared it well enough that it won't return.";
                    break;
                case 1:  //the town square
                    console.text += "  You convince the townspeople to leave out bowls of milk and extiguish flames on nights when a life has been lost to avoid attracting the cat back again.";
                    break;
                case 2:  //The lake
                    console.text += "  You keep your distance and begin fishing in the lake.  When you catch something, you offer it to the cat, who takes it and runs.  It seems appeased.";
                    break;
                case 3:  //The faery circle
                    console.text += "  You leave an offering of some food to win the cat's good favor.  It eats, and then dissapears into shadows.  The townspeaople never see it again.";
                    break;
                case 4:   //the graveyard
                    console.text += "  This is the worst possible place the cat sidhe could be.  You collect the children of the town to play some games, destracting the cat and allowing you to lead it away from the town.";
                    break;
            }
        }
        
        if (currentEvent.GetCreature() == 1)  //cu sidhe ending text
        {
            switch (currentEvent.GetLocation())
            {
                case 0:  //the woods
                    console.text += "  You instruct the townspeople that they should get inside if they hear howling, as the third howl has been known to take lives.";
                    break;
                case 1:  //the town square
                    console.text += "  You instruct the townspeople that they should stay in at night as long as they suspect the cu sidhe may be around.";
                    break;
                case 2:  //The lake
                    console.text += "  You instruct the men of the town to keep their wives and children safe.";
                    break;
                case 3:  //The faery circle
                    console.text += "  You don't approach the faery circle.  You can see the dog from a distance, and as you're watching it disappears.";
                    break;
                case 4:  //the graveyard
                    console.text += "  You instruct the townspeople that they should get inside if they hear howling, as the third howl has been known to take lives.";
                    break;
            }
        }
        
        if (currentEvent.GetCreature() == 2)  //aes sidhe ending text
        {
            switch (currentEvent.GetLocation())
            {
                case 0:  //the woods
                    console.text += "  You take an offering to edge of the woods and leave it as an apology for the town's transgressions.";
                    break;
                case 1:  //the town square
                    console.text += "  You teach the townspeople that they must be careful not to insult the aes sidhe, as they will retaliate if angry.";
                    break;
                case 2:  //The lake
                    console.text += "  You speak to the fishermen dotting the edge of the lake and convince them to each leave some of their catch each day as an offering.";
                    break;
                case 3:  //The faery circle
                    console.text += "  You encounter the aes sidhe herself at the faery circle.  You talk to her, careful not to tell her your name or where you live.  On behalf of the town you apologize for coming too close.";
                    break;
                case 4: //the graveyard
                    console.text += "  She looks like a ghost in the graveyard.  You do not approach her, as it seems unwise to disturb her walk through the dead.";
                    break;
            }
        }
        
        if (currentEvent.GetCreature() == 3)  //morrighan ending text
        {
            switch (currentEvent.GetLocation())
            {
                case 0:  //the woods
                    console.text += "  You find a lone blackbird who hops along the path. After a moment, she flaps her wings and flys away.";
                    break;
                case 1:  //the town square
                    console.text += "  A black-haired woman walks through town carrying bloodied clothes.  Townspeople skitter out of her way, but once she is gone they do not see her again.";
                    break;
                case 2:  //The lake
                    console.text += "  A blackbird flies above the lake.  You thank her for the warning, and she glides away.";
                    break;
                case 3:  //The faery circle
                    console.text += "  A woman with black hair stands in the center of a circle, head held high.  She stares at you and blinks, then walks away.";
                    break;
                case 4:  //the graveyard
                    console.text += "  A blackbird lingers near a newly-dug grave.  She hops a few times before flying away as you approach.";
                    break;
            }
        }
        
        if (currentEvent.GetCreature() == 4)  //kelpie ending text
        {
            switch (currentEvent.GetLocation())
            {
                case 0: //the woods
                    console.text += "  A white horse walks gracefully through the woods.  You warn the chdren, who gawk at it, to return to town and safety.  They do as you said, but talk about the horse for weeks afterwards.";
                    break;
                case 1:  //the town square
                    console.text += "  A man with water weeds dripping from his white-blonde hair speaks to one of the townspeople.  You watch to be sure the townsfolk are not charmed by him, and eventually he leaves alone.";
                    break;
                case 2:  //The lake
                    console.text += "  As you approach, a white horse climbs from under the water with long, gliding steps.  " +
                        "You tell him plainly that you shall not follow him, and nor shall any one else.  He shakes his head, but re-submerges himself anyway.";
                    break;
                case 3:  //The faery circle
                    console.text += "  A man with water weeds dripping from his white-blonde hair kneels on the ground just outside the ring.  You ask him politely to leave this town alone.  To your surprise, he obliges.";
                    break;
                case 4:  //the graveyard
                    console.text += "  A ghostly white horse trots through the graveyard, only stopping to shake his mane at you.  He dissapears into the woods outside, and isn't seen again.";
                    break;
            }
        }
    }
}
