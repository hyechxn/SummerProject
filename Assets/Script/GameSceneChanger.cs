using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSceneChanger : MonoBehaviour
{
    public GameObject[] Page;
    public GameObject Help;
    public TextMeshProUGUI curPage;
    public GameObject NextButton;
    public GameObject PreviousButton;
    public void GoStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void NextPage()
    {
        Page[0].SetActive(false);
        Page[1].SetActive(true);
        PreviousButton.SetActive(true);
        NextButton.SetActive(false);
        curPage.text = "2/2";
    }

    public void PrevPage()
    {
        Page[0].SetActive(true);
        Page[1].SetActive(false);
        NextButton.SetActive(true);
        PreviousButton.SetActive(false);
        curPage.text = "1/2";
    }
    public void ViewHelp()
    {
        Help.SetActive(true);
        Page[0].SetActive(true);
        Page[1].SetActive(false);
        NextButton.SetActive(true);
        PreviousButton.SetActive(false);
        curPage.text = "1/2";
    }
    public void UnViewHelp()
    {
        Help.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
