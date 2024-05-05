using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine.AI;
using System;

public class UserInput_Pyr : MonoBehaviour
{
    private Solitaire_Pyramid solitaire;
    public GameObject slot1 = null;
    private static float xOffset = 0.05f;

    private static T FindAnyObjectByType<T>(string v)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        solitaire = FindObjectOfType<Solitaire_Pyramid>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        var layerMask = 1 << 8;
        layerMask = ~layerMask;
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layerMask);
            if(hit)
            {
                if(hit.collider.CompareTag("Deck_Pyr"))
                {
                    Deck();
                }
                else if(hit.collider.CompareTag("Card_Pyr"))
                {
                    Card(hit.collider.gameObject);
                }
                else if(hit.collider.CompareTag("Bottom_Pyr"))
                {
                    print("bottom");
                }                 
            }
        }
    }
    void Deck()
    {
        print("clicked on deck");
        solitaire.DealFromDeck();
    }
    void Card(GameObject selected)
    {
        print("clicked on card");
        if(Unlocked(selected) && selected.GetComponent<Selectable_Pyr>().pickable)
        {
            // selected first card
            if(slot1 == null) 
            {
                slot1 = selected;
                if(slot1.GetComponent<Selectable_Pyr>().value == 13)
                {
                    Stack();
                    slot1 = null;
                }
            }
            // the same card is selected multiple times
            else if(slot1 == selected)
            {
                if(slot1.GetComponent<Selectable_Pyr>().value == 13)
                {
                    Stack();
                    slot1 = null;
                }
            }
            // second card is selected
            else if(slot1 != selected && slot1 != null)
            {
                if(Stackable(selected))
                {
                    Stack(selected);
                    slot1 = null;
                }
                else
                {
                    slot1 = selected;
                }
            }
        }
    }
    
    bool Stackable(GameObject selected)
    {
        Selectable_Pyr s1 = slot1.GetComponent<Selectable_Pyr>();
        Selectable_Pyr s2 = selected.GetComponent<Selectable_Pyr>();
    
        if((s1.value + s2.value) == 13)
        {
            print("Pairable");
            return true;
        }
        return false;
    }
    void Stack(GameObject selected)
    {
        Selectable_Pyr s1 = slot1.GetComponent<Selectable_Pyr>();
        Selectable_Pyr s2 = selected.GetComponent<Selectable_Pyr>();
        string card1 = s1.suit + s1.valueString;
        string card2 = s2.suit + s2.valueString;
        if((s1.value + s2.value) == 13)
        {
            print("remove");
            //s1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y - 100f, selected.transform.position.z);
            //s2.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y - 100f, selected.transform.position.z);
            s1.transform.position = new Vector3(solitaire.discardCard.transform.position.x + xOffset, solitaire.discardCard.transform.position.y, solitaire.discardCard.transform.position.z);
            s2.transform.position = new Vector3(solitaire.discardCard.transform.position.x + xOffset + xOffset, solitaire.discardCard.transform.position.y, solitaire.discardCard.transform.position.z);
            s1.pickable = false;
            s2.pickable = false;
            xOffset += 0.05f;
            for (int i = 0; i < 7; i++){
                for(int j = 0; j <= i; j++){
                    if(card1.Equals(solitaire.pyramid[i, j]))
                    {
                        solitaire.pyramid[i, j] = "empty";
                    
                    }
                    if(card2.Equals(solitaire.pyramid[i,j]))
                    {
                        solitaire.pyramid[i, j] = "empty";
                    }
            }
        }
            //solitaire.tripsOnDisplay.Remove(slot1.name);
            //slot1 = this.gameObject;
        }
    }
    void Stack()
    {
        Selectable_Pyr s1 = slot1.GetComponent<Selectable_Pyr>();
        print("remove");
        // s1.transform.position = new Vector3(s1.transform.position.x, s1.transform.position.y - 1000f, s1.transform.position.z);
        s1.transform.position = new Vector3(solitaire.discardCard.transform.position.x + xOffset, solitaire.discardCard.transform.position.y, solitaire.discardCard.transform.position.z);
        s1.pickable = false;
        xOffset += 0.05f;
        string card1 = s1.suit + s1.valueString;
        for (int i = 0; i < 7; i++)
        {
            for(int j = 0; j <= i; j++)
            {
                if(card1.Equals(solitaire.pyramid[i, j]))
                {
                    solitaire.pyramid[i, j] = "empty";
                    
                }
            }
        }
        //slot1 = this.gameObject;
    }
    bool Unlocked(GameObject selected)
    {
        int i = 0;
        int j = 0;
        bool exitOuterLoop = false;
        string card = selected.GetComponent<Selectable_Pyr>().suit + selected.GetComponent<Selectable_Pyr>().valueString;
        print(card);
         for (i = 0; i < 7; i++){
            for(j = 0; j <= i; j++){
                if(card.Equals(solitaire.pyramid[i, j]))
                {
                    print(solitaire.pyramid[i, j]);
                    exitOuterLoop = true;
                    break;
                }
            }
            if (exitOuterLoop)
            {
                break;
            }
        }
        print(i);
        print(j);

        if(i >= 6 || j >= 6)
        {
            return true;
        }
        else if(solitaire.pyramid[i + 1, j].Equals("empty") && solitaire.pyramid[i + 1, j + 1].Equals("empty"))
        {
            return true;
        }

        return false;
    }
}
