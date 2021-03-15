using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    //private string[] creatures = new string[] { "cat sidhe", "cu sidhe", "aes sidhe", "Morrigan", "kelpie" };
    //private string[] locations = new string[] { "the wood", "town square", "the lake", "fairy circle", "graveyard"};
    private string startText = "The townspeople are all talking about something mysterious having happened!  Why don't you go see what it is?";

    public EventContainer currentEvent;
    public Text console;
    public Text locationText;
    public GameObject[] NPCs;
    public GameObject goToButton;
    public GameObject researchButton;
    public GameObject researchMenu;
    public GameObject locationMenu;
    public GameObject[] buttons;
    private int[] canGoToCurrently = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        int creatureIndex = Random.Range(0, 4);
        int locationIndex = Random.Range(0, 4);
        currentEvent.SetEvent(creatureIndex, locationIndex);

        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<Animator>().SetBool("eventOccured", true);
            if (locationIndex == i || (locationIndex + 1) == i)
            {
                NPCs[i].GetComponent<Animator>().SetInteger("proximity", 0);
            }
            else if ((locationIndex + 2) == i)
            {
                NPCs[i].GetComponent<Animator>().SetInteger("proximity", 1);
            }
            else
            {
                NPCs[i].GetComponent<Animator>().SetInteger("proximity", 2);
            }
        }
        locationMenu.SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        researchMenu.SetActive(false);

        console.text = startText;
        locationText.text = "Home";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToButton()
    {
        goToButton.SetActive(false);
        researchButton.SetActive(false);

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

    public void ResearchButtonBehavior()
    {
        researchMenu.SetActive(true);
        locationMenu.SetActive(false);
    }

    public void ResearchBackBehavior()
    {
        researchMenu.SetActive(false);
        locationMenu.SetActive(true);
    }

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
    }

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
    }

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
    }

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
    }

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
    }
}
