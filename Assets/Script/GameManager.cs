using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Item;
    public GameObject[] enemyObs;
    public Transform[] spawnPoints;
    public GameObject BossEnem;
    public GameObject BossEnemy;
    public bool isPaused;
    public float maxEnemySpawnDelay;
    private float curEnemySpawnDelay;

    public int score;

    public GameObject[] enemys;
    public Enemy[] enemyScripts;

    public GameObject UIManager;
    private UI um;

    public GameObject buletLevelChanger;
    public GameObject healthChanger;
    public GameObject painChanger;
    public GameObject levelChanger;

    public int Stage;


    public int bossCount;

    public GameObject pauseMenu;
    public GameObject GameOverMenu;
    public UnityEngine.UI.Button resumeButton;

    public bool isBoss;

    public float maxItemSpawnDelay = 20f;
    private float curItemSpawnDelay;

    public GameObject bossHealthBar;

    public int enemyNum;


    private bool isGodMode;

    private int godHealth;
    private int godPain;
    void Start()
    {

        Stage = 1;
        um = UIManager.GetComponent<UI>();
        Time.timeScale = 1.0f;
        isPaused = false;
        resumeButton.onClick.AddListener(Pause);
    }
    void Update()
    {
        cheatKey();
        if (isGodMode)
        {
            um.CurHp = godHealth;
            um.CurPain = godPain;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
        if (isBoss == false)
        {
            if (bossCount >= 10)
            {
                Vector3 trans = new Vector3(0f, 8f, 0f);
                if (Stage == 1)
                    Instantiate(BossEnem, trans, transform.rotation);
                else if (Stage == 2)
                    Instantiate(BossEnemy, trans, transform.rotation);
                um.bossHealth.SetActive(true);
                bossCount = 0;
                isBoss = true;
            }
            SpawnEnem();
            SpawnIte();
        }
        GameOverCheck();


        Time.timeScale = isPaused ? 0.0f : 1.0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            MonoBehaviour[] scripts = playerObj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = !isPaused;
            }
        }
    }

    private void cheatKey()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            int ranPoint = Random.Range(1, 5);
            GameObject item = Instantiate(Item[0], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            Item itemLogic = item.GetComponent<Item>();
            if (ranPoint <= 3 && ranPoint > 0)
            {//front
                rigid.velocity = new Vector2(0, 3 * (-1));
                itemLogic.Direction = "Front";
            }
            else if (ranPoint == 0 || ranPoint == 6)//left
            {
                rigid.velocity = new Vector2(3, -1);
                itemLogic.Direction = "Left";
            }
            else if (ranPoint == 4 || ranPoint == 5)//right
            {
                rigid.velocity = new Vector2(3 * (-1), -1);
                itemLogic.Direction = "Right";
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            int ranPoint = Random.Range(1, 5);
            GameObject item = Instantiate(Item[1], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            Item itemLogic = item.GetComponent<Item>();
            if (ranPoint <= 3 && ranPoint > 0)
            {//front
                rigid.velocity = new Vector2(0, 3 * (-1));
                itemLogic.Direction = "Front";
            }
            else if (ranPoint == 0 || ranPoint == 6)//left
            {
                rigid.velocity = new Vector2(3, -1);
                itemLogic.Direction = "Left";
            }
            else if (ranPoint == 4 || ranPoint == 5)//right
            {
                rigid.velocity = new Vector2(3 * (-1), -1);
                itemLogic.Direction = "Right";
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            Enemy[] enemyScripts = new Enemy[enemys.Length];

            for (int i = 0; i < enemys.Length; i++)
            {
                enemyScripts[i] = enemys[i].GetComponent<Enemy>();
                enemyScripts[i].health = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {

            buletLevelChanger.SetActive(true);

            isPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {

            healthChanger.SetActive(true);

            isPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {

            painChanger.SetActive(true);

            isPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            OnGodMode();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {

            OffGodMode();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            isBoss = true;
            levelChanger.SetActive(true);

            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            Enemy[] enemyScripts = new Enemy[enemys.Length];

            for (int i = 0; i < enemys.Length; i++)
            {
                Destroy(enemyScripts[i]);
            }
        }
    }



    public void OnGodMode()
    {
        isGodMode = true;
        godHealth = um.CurHp;
        godPain = um.CurPain;
    }

    public void OffGodMode()
    {
        isGodMode = false;
    }

    void SpawnIte()
    {
        curItemSpawnDelay += Time.deltaTime;

        if (curItemSpawnDelay >= maxItemSpawnDelay)
        {
            SpawnItem();
            maxItemSpawnDelay = Random.Range(6f, 18f);
            curItemSpawnDelay = 0;
        }
    }
    void SpawnItem()
    {
        int ItemNum = Random.Range(0, 2);

        int ranPoint = Random.Range(1, 5);
        GameObject item = Instantiate(Item[ItemNum], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
        Item itemLogic = item.GetComponent<Item>();
        if (ranPoint <= 3 && ranPoint > 0)
        {//front
            rigid.velocity = new Vector2(0, 3 * (-1));
            itemLogic.Direction = "Front";
        }
        else if (ranPoint == 0 || ranPoint == 6)//left
        {
            rigid.velocity = new Vector2(3, -1);
            itemLogic.Direction = "Left";
        }
        else if (ranPoint == 4 || ranPoint == 5)//right
        {
            rigid.velocity = new Vector2(3 * (-1), -1);
            itemLogic.Direction = "Right";
        }
    }
    void SpawnEnem()
    {
        curEnemySpawnDelay += Time.deltaTime;

        if (curEnemySpawnDelay >= maxEnemySpawnDelay)
        {
            SpawnEnemy();
            maxEnemySpawnDelay = Random.Range(0.7f, 2f);
            curEnemySpawnDelay = 0;
        }
    }
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(1, 100);
        Debug.Log(ranEnemy);
        if (ranEnemy < 60)
        {
            enemyNum = 0;
        }
        else if (ranEnemy < 85)
        {
            enemyNum = 1;
        }
        else if (ranEnemy <= 100)
        {
            enemyNum = 2;
        }

        int ranPoint = Random.Range(0, 7);
        bossCount++;
        GameObject enemy = Instantiate(enemyObs[enemyNum], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        if (ranPoint <= 3 && ranPoint > 0)
        {//front
            rigid.velocity = new Vector2(0, enemyLogic.speed * (-1));
            enemyLogic.Direction = "Front";
        }
        else if (ranPoint == 0 || ranPoint == 6)//left
        {
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
            enemyLogic.Direction = "Left";
        }
        else if (ranPoint == 4 || ranPoint == 5)//right
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
            enemyLogic.Direction = "Right";
        }
    }
    void GameOverCheck()
    {
        if (um.CurHp <= 0 || um.CurPain >= 300)
        {
            isPaused = true;
            GameOver();
        }
    }
    void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = isPaused ? 0.0f : 1.0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            MonoBehaviour[] scripts = playerObj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = !isPaused;
            }
        }
    }
    void Pause()
    {
        isPaused = !isPaused;

        if (pauseMenu.activeSelf)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
        }

        Time.timeScale = isPaused ? 0.0f : 1.0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            MonoBehaviour[] scripts = playerObj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = !isPaused;
            }
        }
    }
}
