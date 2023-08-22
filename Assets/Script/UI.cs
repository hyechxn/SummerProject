using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]

    public GameObject boss;
    public GameObject player;
    public Slider hpBar;
    public Slider painBar;
    public Slider BossHealth;
    public TextMeshProUGUI tMP;
    public TextMeshProUGUI Item;
    public TextMeshProUGUI hpGauge;
    public TextMeshProUGUI painGauge;
    public TextMeshProUGUI stage1;
    public int score=0;

    public GameObject itemTextObject;
    public GameObject bossHealth;

    public string nameNameItem;
    public string showItem;
    public bool isItem;
    public int CurHp=200;
    public int MaxHp=200;

    public int CurPain=20;
    public int MaxPain=200;

    public int CurBossHealth = 1000;
    public int MaxBossHealth = 1000;
    private float alpha;

    public GameObject Heal;
    public GameObject Pain;
    public GameObject AtkSpeed;
    public GameObject Upgrade;
    public GameObject NoHit;
    void Awake()
    {
        itemTextObject.SetActive(false);
        hpBar.value = 1f;
        isItem = false;
        painBar.value = 0.1f;
    }

     void Start()
    {
        for (float i = 1; i <= 0; i -= 0.1f)
        {
            float alpha = i;
            Color currentColor = new Color(1, 1, 1, 1f);
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            stage1.color = newColor;
        }
    }

    void Update()
    {
        tMP.text = score.ToString();
        hpGauge.text = CurHp + " / " + MaxHp;
        painGauge.text = (((float)CurPain / MaxPain) * 100.0f).ToString("0.0") + "%";
        painBar.value = (float)CurPain / MaxPain;
        BossHealth.value = (float)CurBossHealth / MaxBossHealth;
        if (CurBossHealth <= 0 )
        {
            Debug.Log("ÀÌÀÌÀ×");
            bossHealth.SetActive(false);
        }
        if (CurPain > 300)
        {
            CurPain = 300;
        }
        hpBar.value = (float)CurHp / MaxHp;
        if (CurHp < 0)
        {
            CurHp = 0;
        }
        

        if (nameNameItem == "NoHit")
        {
            NoHit.SetActive(true);
            Invoke("FalseNohit", 3);
        }
        else if (nameNameItem == "Healing")
        {
            Heal.SetActive(true);
            Invoke("FalseHeal", 3);
        }
        else if (nameNameItem == "Upgrade")
        {
            Upgrade.SetActive(true);
            Invoke("FalseUpgrade", 3);
        }
        else if (nameNameItem == "PainDown")
        {
            Pain.SetActive(true);
            Invoke("FalsePain", 3);
        }
        else if (nameNameItem == "AtkSpeedUp")
        {
            AtkSpeed.SetActive(true);
            Invoke("FalseAtkSpeed", 3);
        }
                
            
        
    }
    void FalsePain()
    {
        isItem = false;
        Pain.SetActive(false);
        nameNameItem = "";
    }
    void FalseUpgrade()
    {
        isItem = false;
        Upgrade.SetActive(false);
        nameNameItem = "";
    }
    void FalseHeal()
    {
        isItem = false;
        Heal.SetActive(false);
        nameNameItem = "";
    }
    void FalseNohit()
    {
        isItem = false;
        NoHit.SetActive(false);
        nameNameItem = "";
    }
    void FalseAtkSpeed()
    {
        isItem = false;
        AtkSpeed.SetActive(false);
        nameNameItem = "";
    }

}
