using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]

    public GameObject player;
    public Slider hpBar;
    public Slider painBar;
    public TextMeshProUGUI tMP;

    public int score;

    public int CurHp=200;
    public int MaxHp=200;

    public int CurPain=30;
    public int MaxPain=300;
    void Start()
    { 
        hpBar.value = 1f;

        painBar.value = 0.1f;
    }

    void Update()
    {
        hpBar.value = (float)CurHp / (float)MaxHp;
        painBar.value = (float)CurPain / (float)MaxPain;

        tMP.text = "Score : "+score  ;
    }

}
