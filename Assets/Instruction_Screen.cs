using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Instruction_Screen : MonoBehaviour
{
    public void ClockInstructions()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void RegularInstructions()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void PyramidInstructions()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void GoBackMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void GoBackInstruction()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
