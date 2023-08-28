using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSceneChanger : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Page;
    public GameObject page3;
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
        if (Page[0].activeSelf)
        {
            Page[0].SetActive(false);
            Page[1].SetActive(true);
            Page[2].SetActive(false);
            PreviousButton.SetActive(true);
            curPage.text = "2/3";
        }
        else if (Page[1].activeSelf) 
        {
            Page[0].SetActive(false);
            Page[1].SetActive(false);
            Page[2].SetActive(true);
            page3.SetActive(true);
            NextButton.SetActive(false);
            curPage.text = "3/3";
        }
    }

    public void PrevPage()
    {
        if (Page[1].activeSelf)
        {
            Page[0].SetActive(true);
            Page[1].SetActive(false);
            Page[2].SetActive(false);
            PreviousButton.SetActive(false);
            NextButton.SetActive(true);
            curPage.text = "1/3";
        }
        else if (Page[2].activeSelf)
        {
            Page[0].SetActive(false);
            Page[1].SetActive(true);
            Page[2].SetActive(false);
            page3.SetActive(false);
            NextButton.SetActive(true);
            curPage.text = "2/3";
        }
    }
    public void ViewHelp()
    {
        Help.SetActive(true);
        Page[0].SetActive(true);
        Page[1].SetActive(false);
        Page[2].SetActive(false);
        page3.SetActive(false);
        NextButton.SetActive(true);
        PreviousButton.SetActive(false);
        curPage.text = "1/3";
    }
    public void UnViewHelp()
    {
        Help.SetActive(false);
        page3.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
