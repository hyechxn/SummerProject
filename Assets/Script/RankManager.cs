using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class RankManager : MonoBehaviour
{
    public String score;

    public TMP_InputField NameInPut;

    [SerializeField]
    public TextMeshProUGUI[] ranker;
    public TextMeshProUGUI[] rankerScore;

    public Rank InputRank = new Rank();
    [SerializeField] List<Rank> ranks = new List<Rank>();

    private void Awake()
    {
        ranker[0].text = " ";
        ranker[1].text = " ";
        ranker[2].text = " ";
        ranker[3].text = " ";
        ranker[4].text = " ";

        rankerScore[0].text = " ";
        rankerScore[1].text = " ";
        rankerScore[2].text = " ";
        rankerScore[3].text = " ";
        rankerScore[4].text = " ";
    }
    void Update()
    {
        InputRank.name = NameInPut.text;
        InputRank.score = score;
            ranker[0].text = "";
            ranker[1].text = " ";
            ranker[2].text = " ";
            ranker[3].text = " ";
            ranker[4].text = " ";

            rankerScore[0].text = " ";
            rankerScore[1].text = " ";
            rankerScore[2].text = " ";
            rankerScore[3].text = " ";
            rankerScore[4].text = " ";
    }

    [Serializable]
    public class Rank
    {
        public String name;
        public String score;

        public Rank(String name, String score)
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
        ranks.Add(InputRank);
    }
}
