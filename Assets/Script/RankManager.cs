using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{

    public int score;
    public Button register;
    public TMP_InputField NameInPut;

    public GameObject SaveScore;
    public SaveScore savedScore;

    private int countList;

    [SerializeField]
    public TextMeshProUGUI viewScore;
    public TextMeshProUGUI[] ranker;
    public TextMeshProUGUI[] rankerScore;

    public Rank InputRank = new Rank();
    [SerializeField] static List<Rank> ranks = new List<Rank>();

    private void Awake()
    {

        SaveScore = GameObject.Find("SaveScore");
        savedScore = SaveScore.GetComponent<SaveScore>();
    }

    private void Start()
    {
        score = savedScore.score;
        viewScore.text = "최종 점수: " + score;
        if (ranks != null)
        {
            if (ranks.Count <= 5)
            {
                countList = ranks.Count;
            }
            ranks.Sort((a, b) => { return b.score - a.score; });
            for (int i = 0; i < countList; i++)
            {
                ranker[i].text = ranks[i].name;
                rankerScore[i].text = ranks[i].score.ToString();
            }
        }
    }
    void Update()
    {

        
        InputRank.score = score;
        InputRank.name = NameInPut.text;

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
        Rank curRank = new Rank();
        curRank.score = score;
        curRank.name = NameInPut.text;
        register.interactable = false;
        ranks.Add(curRank);
        if (ranks.Count <= 5)
        {
            countList = ranks.Count;
        }
        ranks.Sort((a, b) => { return b.score - a.score; });
        for (int i = 0; i < countList; i++)
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
