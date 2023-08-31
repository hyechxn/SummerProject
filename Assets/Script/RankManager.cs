using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{

    public int score;
    public Button refister;
    public TMP_InputField NameInPut;

    public GameObject SaveScore;
    public SaveScore savedScore;

    [SerializeField]
    public TextMeshProUGUI viewScore;
    public TextMeshProUGUI[] ranker;
    public TextMeshProUGUI[] rankerScore;

    public Rank InputRank = new Rank();
    [SerializeField] List<Rank> ranks = new List<Rank>();

    private void Awake()
    {
        


        SaveScore = GameObject.Find("SaveScore");
        savedScore = SaveScore.GetComponent<SaveScore>();
    }
    void Update()
    {

        score = savedScore.score ;
        viewScore.text = "최종 점수: " + savedScore.score.ToString();
        InputRank.score = score;
        
    }

    [Serializable]
    public class Rank
    {
        public String name;
        public int score;

        public Rank(String name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public Rank()
        {

        }
    }
    public void Register()
    {
        InputRank.name = NameInPut.text;
        refister.interactable = false;
        ranks.Add(InputRank);
        ranks.Sort((a, b) => { return a.score - b.score; });
        for (int i = 0; i < 5; i++) 
        {
            ranker[i].text = ranks[i].name;
            rankerScore[i].text = ranks[i].score.ToString();
        }
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ReGame()
    {
        SceneManager.LoadScene("Stage1");
    }
}
