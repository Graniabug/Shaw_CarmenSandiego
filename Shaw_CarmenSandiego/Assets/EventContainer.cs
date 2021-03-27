/*************************************************************************************************************************
 * Name: EventContainer
 * Description: Holds data about the current event and allows access to it via functions
 * Attached to: 
 *      Scene: SampleScene
 *      Object: Canvas
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

public class EventContainer : MonoBehaviour
{
    private int currentCreature = 100;  //stores the index of the current creature
    private int currentLocation = 100;  //stores the index of the current location

    public bool creatureFound = false;  //true if the player has found the creature via the research screen (see ResearchBehavior.cs), false if not (set in EventManager.cs)

    /**************************************************
    * Name: GetCreature
    * Description: returns the integer index of the current creature
    *    0 = cat sidhe
    *    1 = cu sidhe
    *    2 = aes sidhe
    *    3 = morrigan
    *    4 = kelpie
    * Original Author: Kayleigh Shaw
    * Called in: 
    *    NpcLocationBehavior -> OnStateEnter()
    *    NpcCreatureBehavior -> OnStateEnter()
    *    EventManager -> CreatureFoundText()
    *    ResearchBehavior -> Option1-3Changed()
    *    ResearchBehavior -> Update()
    * ************************************************/
    public int GetCreature()
    {
        return currentCreature;
    }

    /**************************************************
    * Name: GetTextCreature
    * Description: returns the name of the current 
    * creature based on the index
    * Original Author: Kayleigh Shaw
    * Called in: 
    *    EventManager -> CreatureFoundText()
    *    ResearchBehavior -> Update()
    * ************************************************/
    public string GetTextCreature()
    {
        switch (currentCreature)
        {
            case 0:
                return "cat sidhe";
            case 1:
                return "cu sidhe";
            case 2:
                return "aes sidhe";
            case 3:
                return "Morrigan";
            case 4:
                return "kelpie";
        }
        return "no creature set";
    }

    /**************************************************
   * Name: GetLocation
   * Description: returns the integer index of the current location
   *    0 = the woods
   *    1 = town square
   *    2 = the lake
   *    3 = the faery circle
   *    4 = the graveyard
   * Original Author: Kayleigh Shaw
   * Called in: 
   *    EventManager -> CreatureFoundText()
   *    NpcLocationBehavior -> PopulateDialogueOptions()
   *    NpcCreatureBehavior -> PopulateDialogueOptions()
   * ************************************************/
    public int GetLocation()
    {
        return currentLocation;
    }

    /**************************************************
    * Name: GetTextLocation
    * Description: returns the name of the current 
    * location based on the index
    * Original Author: Kayleigh Shaw
    * Called in: none
    * ************************************************/
    public string GetTextLocation()
    {
        switch (currentLocation)
        {
            case 0:
                return "the woods";
            case 1:
                return "town square";
            case 2:
                return "the lake";
            case 3:
                return "fairy circle";
            case 4:
                return "graveyard";
        }
        return "no location set";
    }

    /**************************************************
    * Name: SetEvent
    * Description: Sets the values for the current event
    * Original Author: Kayleigh Shaw
    * Inputs: int newCreature, int newLocation
    * Called in: EventManager -> Start()
    * ************************************************/
    public void SetEvent(int newCreature, int newLocation)
    {
        currentCreature = newCreature;
        currentLocation = newLocation;
    }
}
