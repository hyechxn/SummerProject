using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RankingPage()
    {
        SceneManager.LoadScene("RankingPage");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
