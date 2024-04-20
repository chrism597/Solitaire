using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput_Pyr : MonoBehaviour
{
    private Solitaire_Pyramid solitaire;
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
                    Card();
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
    void Card()
    {
        print("clicked on card");
    }
    void Bottom()
    {
        print("clicked on bottom");
    }
}
