using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject highScorePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        highScorePanel.SetActive(false);
        ResetScene();
    }

    public void ResetScene()
    {
        // find all the cards and remove them
        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        print("Number of cards that have been used ---> " + cards.Length);
        foreach (UpdateSprite card in cards)
        {
            if (!String.Equals(card.gameObject.name, "Card"))
            {
                print("Card that has been used ---> " + card.gameObject.name);
                Destroy(card.gameObject);
            }
        }
        ClearTopValues();
        // deal new cards
        FindObjectOfType<UserInput>().slot1 = FindObjectOfType<UserInput>().gameObject;
        FindObjectOfType<Solitaire>().PlayCards();
    }

    void ClearTopValues()
    {
        Selectable[] selectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in selectables)
        {
            if (selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }

}
