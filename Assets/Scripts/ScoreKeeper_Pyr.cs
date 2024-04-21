using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper_Pyr : MonoBehaviour
{
    private Solitaire_Pyramid solitaire;
    public GameObject highscorePanel;
    // Start is called before the first frame update
    void Start()
    {
        solitaire = FindObjectOfType<Solitaire_Pyramid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HasWon())
        {
            Win();
        }
    }
    public bool HasWon()
    {
        int counter = 0;
        for (int i = 0; i < 7; i++){
            for(int j = 0; j <= i; j++){
                if(solitaire.pyramid[i, j].Equals("empty")){
                    counter++;
                }
            }
        }
        if(counter == 28){
            
            return true;
        }
        else{
            return false;
        }
    }
    void Win()
    {
        highscorePanel.SetActive(true);
        print("You Won!");
    }
}
