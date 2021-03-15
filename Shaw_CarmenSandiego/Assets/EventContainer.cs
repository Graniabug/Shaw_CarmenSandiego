using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour
{
    private int currentCreature = 100;
    private int currentLocation = 100;

    public int GetCreature()
    {
        return currentCreature;
    }

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

    public int GetLocation()
    {
        return currentLocation;
    }

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
        return "no creature set";
    }

    public void SetEvent(int newCreature, int newLocation)
    {
        currentCreature = newCreature;
        currentLocation = newLocation;
    }
}
