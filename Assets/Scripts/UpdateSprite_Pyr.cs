using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite_Pyr : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable_Pyr selectable;
    private Solitaire_Pyramid solitaire;
    private UserInput_Pyr userInput;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Solitaire_Pyramid.GenerateDeck();
        solitaire = FindObjectOfType<Solitaire_Pyramid>();
        userInput = FindObjectOfType<UserInput_Pyr>();

        int i = 0;
        foreach (string card in deck)
        {
            if(this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable_Pyr>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == false)
        {
            spriteRenderer.sprite = cardFace;
        }
        else{
            spriteRenderer.sprite = cardFace;
        }
        if(userInput.slot1)
        {
            if(name == userInput.slot1.name)
            {
            spriteRenderer.color = Color.yellow;
            }
            else
            {
            spriteRenderer.color = Color.white;
            }
        }
        
    }
}
