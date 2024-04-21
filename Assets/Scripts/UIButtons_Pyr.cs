using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons_Pyr : MonoBehaviour
{
    public GameObject highscorePanel;
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
        highscorePanel.SetActive(false);
        ResetScene();
    }
    public void ResetScene()
    {
        // find all the cards and remove them
        UpdateSprite_Pyr[] cards = FindObjectsOfType<UpdateSprite_Pyr>();
        foreach (UpdateSprite_Pyr card in cards)
        {
            Destroy(card.gameObject);
        }
        // deal new cards
        FindObjectOfType<Solitaire_Pyramid>().PlayCards();
    }
}
