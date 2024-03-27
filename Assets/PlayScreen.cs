using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayScreen : MonoBehaviour
{
    public void PlayClock()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void PlayRegular()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void PlayPyramid()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void GoMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
