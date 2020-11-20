using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public void toGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void toInstructionScene()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void toMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void toGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}