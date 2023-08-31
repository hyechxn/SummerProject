using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRanks : MonoBehaviour
{
    public static SaveRanks Instance;

    [SerializeField] List<Rank> ranks = new List<Rank>();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

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
