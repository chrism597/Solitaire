using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void OpenInstructions()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
