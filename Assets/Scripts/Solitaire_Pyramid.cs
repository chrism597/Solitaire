using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Solitaire_Pyramid : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject[] bottomPos;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string>[] bottoms;
    private List<string> bottom0 = new List<string>();
    private List<string> bottom1 = new List<string>();
    private List<string> bottom2 = new List<string>();
    private List<string> bottom3 = new List<string>();
    private List<string> bottom4 = new List<string>();
    private List<string> bottom5 = new List<string>();
    public List<string> deck;

    // Start is called before the first frame update
    void Start()
    {
        bottoms = new List<string>[] {bottom0, bottom1,bottom2,bottom3,bottom4,bottom5};
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
        SolitaireSort();
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
    void SolitaireSort()
    {
        for (int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                bottoms[j].Add(deck.Last<string>());
                deck.RemoveAt(deck.Count - 1);
            }
        }
    }
    void SolitaireDeal()
    {
        for(int i = 0; i < 6; i++)
        {
            float xOffset = 0;
            float yOffset = 0;
            float zOffset = 0;
            foreach(string card in bottoms[i]){
            GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[i].transform.position.x + xOffset, bottomPos[i].transform.position.y + yOffset, bottomPos[i].transform.position.z + zOffset) , Quaternion.identity, bottomPos[i].transform);
            newCard.name = card;
            newCard.GetComponent<Selectable_Pyr>().faceUp = true;
            //yOffset = yOffset - 0.1f;
            zOffset = zOffset + 0.03f;
            xOffset = xOffset + 1f;
            }
        }
        
    }
    
}
