using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Solitaire_Play : MonoBehaviour
{
    public void GoBackSolitairePlay()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
