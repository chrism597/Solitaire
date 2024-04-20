using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class UserInput_Pyr : MonoBehaviour
{
    private Solitaire_Pyramid solitaire;
    public GameObject slot1;
    // Start is called before the first frame update
    void Start()
    {
        solitaire = FindObjectOfType<Solitaire_Pyramid>();
        slot1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
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
        if(slot1 == this.gameObject)
        {
            slot1 = selected;
            if(slot1.GetComponent<Selectable_Pyr>().value == 13)
            {
                Stack();
                
            }
        }
        else if(slot1 != selected || slot1 != null)
        {
            if(Stackable(selected))
            {
                Stack(selected);
            }
            else
            {
                slot1 = selected;
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
        if((s1.value + s2.value) == 13){}
        {
            print("remove");
            s1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y -100f, selected.transform.position.z);
            s2.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y -100f, selected.transform.position.z);
            //solitaire.tripsOnDisplay.Remove(slot1.name);
            slot1 = this.gameObject;
            
        }
    }
    void Stack()
    {
        Selectable_Pyr s1 = slot1.GetComponent<Selectable_Pyr>();
        print("remove");
        s1.transform.position = new Vector3(s1.transform.position.x, s1.transform.position.y -100f, s1.transform.position.z);
        slot1 = this.gameObject;
    }
}
