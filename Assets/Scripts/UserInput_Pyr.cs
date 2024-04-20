using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput_Pyr : MonoBehaviour
{
    private Solitaire_Pyramid solitaire;
    public GameObject slot1;
    // Start is called before the first frame update
    void Start()
    {
        solitaire = FindObjectOfType<Solitaire_Pyramid>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
        slot1 = this.gameObject;
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
                else if(hit.collider.CompareTag("Bottom_Pyr"))
                {
                    Bottom();
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
        if(slot1 == this. gameObject)
        {
            slot1 = selected;

        }

        else if(slot1 != selected){
            if(Stackable(selected))
            {

            }
            else
            {
                slot1 = selected;
            }
            

        }
    }
    void Bottom()
    {
        print("clicked on bottom");
    }

    bool Stackable(GameObject selected)
    {
        Selectable_Pyr s1 = slot1.GetComponent<Selectable_Pyr>();
        Selectable_Pyr s2 = selected.GetComponent<Selectable_Pyr>();
        
        if(s1.value + s2.value == 13){
            return true;

        }
        return false;
    }
}
