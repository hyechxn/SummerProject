using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public TextMeshProUGUI stage1Text;
    public GameObject stage2Text;
    public GameObject stage1;
    public GameObject stage1Clear;
    public GameObject stage2Clear;
    public GameManager gm;
    public GameObject gameManager;
    public int score = 0;

    public float fadeSpeed = 0.05f;

    public GameObject itemTextObject;
    public GameObject bossHealth;

    public GameObject SaveScore;
    public SaveScore savedScore;

    public string nameNameItem;
    public string showItem;
    public bool isItem;
    public int CurHp = 200;
    public int MaxHp = 200;

    public float alpha;

    public int CurPain = 20;
    public int MaxPain = 200;

    public int CurBossHealth = 1000;
    public int MaxBossHealth = 1000;

    public GameObject Heal;
    public GameObject Pain;
    public GameObject AtkSpeed;
    public GameObject Upgrade;
    public GameObject NoHit;


    public bool IsStage2;

    public GameObject stageFade;

    void Awake()
    {
        SaveScore = GameObject.Find("SaveScore");
        savedScore = SaveScore.GetComponent<SaveScore>();
        gm = gameManager.GetComponent<GameManager>();
        player = GameObject.Find("Player");
        itemTextObject.SetActive(false);
        hpBar.value = 1f;
        isItem = false;
        painBar.value = 0.1f;
    }
    private void Start()
    {
        Invoke("Stage1", 1.5f);
    }

    void Update()
    {
        savedScore.score = score;

        tMP.text = score.ToString();
        hpGauge.text = CurHp + " / " + MaxHp;
        painGauge.text = (((float)CurPain / MaxPain) * 100.0f).ToString("0.0") + "%";
        painBar.value = (float)CurPain / MaxPain;
        BossHealth.value = (float)CurBossHealth / MaxBossHealth;
        if (gm.Stage == 1)
        {
            if (CurBossHealth <= 0)
            {
                bossHealth.SetActive(false);
                Invoke("Stage1Clear", 0.1f);
                CurBossHealth = 2000;
                MaxBossHealth = 2000;
            }
        }
        else if (gm.Stage == 2)
        {
            if (CurBossHealth <= 0)
            {
                bossHealth.SetActive(false);
                Invoke("Stage2Clear", 0.1f);
            }
        }
        if (CurPain > 300)
        {
            CurPain = 300;
        }
        else if (CurPain < 0)
        {
            CurPain = 0;
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

        if (gm.Stage == 2 && IsStage2)
        {
            SettingStage2();
        }

    }

    void SettingStage2()
    {
        stage1Clear.SetActive(false);

        hpGauge.text = CurHp + " / " + MaxHp;
        hpBar.value = (float)CurHp / MaxHp;
        IsStage2 = true;
        Invoke("Stage2Set", 0.1f);
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
    void Stage1Clear()
    {
        stage1Clear.SetActive(true);
        Invoke("GoStage2", 4);
    }
    void Stage2Clear()
    {
        stage2Clear.SetActive(true);
        Invoke("GoRanking", 4);
    }
    void GoRanking()
    {
        SceneManager.LoadScene("RankingPage");
    }
    void GoStage2()
    {
        stageFade.SetActive(true);
        Invoke("FalseFade", 2);
    }
    void Stage2Set()
    {
        stage2Text.SetActive(true);
        MaxBossHealth = 2000;
        Invoke("Stage2", 3f);
    }
    void FalseFade() { stage1Clear.SetActive(false); }
    void Stage1()
    {
        stage1.SetActive(false);
    }
    void Stage2()
    {
        stage2Text.SetActive(false);
    }
}
