using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solitaire_Pyramid : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string> deck;
    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        foreach(string card in deck)
        {
            print(card);
        }
        SolitaireDeal();
    }
    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T temp = list[j];
            list[j] = list[i];
            list[i] = temp;
        }
    }
    void SolitaireDeal()
    {
        foreach(string card in deck){
             GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            newCard.name = card;
        }
    }
}
