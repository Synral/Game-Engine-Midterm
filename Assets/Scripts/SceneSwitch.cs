using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void enterMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void enterPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void enterScoreScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}