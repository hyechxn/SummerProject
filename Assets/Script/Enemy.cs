using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TerrainTools;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;

    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;
    public GameObject bulletC1;
    public GameObject bulletCRotete;

    private float delayTime = 3f;
    private float delay;
    private bool isFire = true;

    public int Level;

    public GameObject Boss;
    private Transform BossTrans;
    public GameObject player;
    public GameObject UIManager;
    public GameObject gameManager;

  

    private int score;
    private float directTime = 1f;
    private float nextTime;

    public string Direction;

    public int dmg;
    private Vector3 initialPlayerPosition;
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    Animator anim;

    private UI NameOfItem;
    private GameManager gm;
    void Awake()
    {


        BossTrans = Boss.transform;
        rigid = GetComponent<Rigidbody2D>();
        if (Level == 10)
        {
            rigid.velocity = Vector2.down * speed;
        }
        if (Level == 1)
        {
            score = 200;
            dmg = 6;
        }
        else if (Level == 2)
        {
            score = 500;
            dmg = 10;
        }
        else if (Level == 3)
        {
            score = 1000;
            dmg = 20;
        }
        else if (Level == 10)
        {
            score = 20000;
            dmg = 10;
        }
        if (Level == 10)
        {
            anim = GetComponent<Animator>();
        }
        UIManager = GameObject.Find("UI Manager");
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        NameOfItem = UIManager.GetComponent<UI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPlayerPosition = player.transform.position;
        gm = gameManager.GetComponent<GameManager>();
    }        

    void Start()
    {
        if (Level ==10)
        {
            return;
        }
        RandomDirect();
    }
    void Update()
    {
        if (Level == 10)
        {
            if (this.transform.position.y <= 2f)
            {
                rigid.velocity = Vector2.zero;
                transform.position = new Vector3(transform.position.x, 2.01f, transform.position.z);
                Invoke("BossThink", 2f);
            }
            return;
        }
        nextTime += Time.deltaTime;
        if (nextTime >= directTime) {
            nextTime = 0;
            RandomDirect();
        }
        Fire();
    }

    void Fire()
    {
        if (isFire == false)
        {
            if(Level == 1)
            {
                Instantiate(bulletA, transform.position, transform.rotation);
                isFire = true;
            }
            if (Level == 2)
            {
                Instantiate(bulletB, transform.position, transform.rotation);
                isFire = true;
            }
            if (Level == 3)
            {
                Instantiate(bulletB, transform.position + Vector3.left * 0.5f, transform.rotation);
                Instantiate(bulletB, transform.position + Vector3.right * 0.5f, transform.rotation);
                isFire = true;
            }
        }
        if (isFire == true)
        {
            delay += Time.deltaTime;
        }
        if (delayTime <= delay)
        {
            isFire = false;
            delay = 0f;
        }

    }

    void BossThink()
    {
        patternIndex = patternIndex==3 ? 0 : patternIndex+1;
        curPatternCount = 0;


        switch (patternIndex)
        {
            case 0:
                FireFoward();
                
                break;
            case 1:
                FireShot();
               
                break;
            case 2:
                FireArc();
                
                break;
            case 3:
                FireAround();
                
                break;
        }
    }

    void FireFoward()
    {
        GameObject bulletL = Instantiate(bulletC1, transform.position + Vector3.left * 0.6f, transform.rotation);
        GameObject bulletLL = Instantiate(bulletC1, transform.position + Vector3.left * 1f, transform.rotation);
        GameObject bulletR = Instantiate(bulletC1, transform.position + Vector3.right * 0.6f, transform.rotation);
        GameObject bulletRR = Instantiate(bulletC1, transform.position + Vector3.right * 1f, transform.rotation);

        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();

        rigidL.AddForce(Vector2.down * 8, ForceMode2D.Impulse);
        rigidLL.AddForce(Vector2.down * 8, ForceMode2D.Impulse);
        rigidR.AddForce(Vector2.down * 8, ForceMode2D.Impulse);
        rigidRR.AddForce(Vector2.down * 8, ForceMode2D.Impulse);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireFoward", 2.5f);
        else
            Invoke("BossThink", 2.5f);
    }
    void FireShot() {
        
        for (int index = 0; index < 8; index++)
        {
            GameObject bullet = Instantiate(bulletC, transform.position, transform.rotation);

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-1.0f,1.0f), Random.Range(0f,2.0f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized*15, ForceMode2D.Impulse);
        }
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", 1.5f);
        else
            Invoke("BossThink", 2.5f);
    }
    void FireArc()
    {
            GameObject bullet = Instantiate(bulletCRotete, transform.position, transform.rotation);
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            float angle = (10 * Mathf.PI * curPatternCount) / maxPatternCount[patternIndex] - Mathf.PI / 2;
            Vector2 dirVec = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireArc", 0.1f);
        else
            Invoke("BossThink", 2.5f);
    }
    void FireAround()
    {
        int roundNumA = 20;
        int roundNumB = 15;
        int roundNum = curPatternCount % 2 == 0 ? roundNumA : roundNumB;

        for (int index = 0; index < roundNum; index++)
        {
            GameObject bullet = Instantiate(bulletCRotete, transform.position, transform.rotation);
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNum), 
                                                             Mathf.Sin(Mathf.PI * 2 * index / roundNum));

            rigid.AddForce(dirVec.normalized * 2, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / roundNum + Vector3.forward * 90;
            bullet.transform.Rotate(rotVec);
        }


        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireAround", 2f);
        else
            Invoke("BossThink", 10f);
    }

    void RandomDirect()
    {
        if (Direction == "Front")
        {
            float moveDirect = Random.Range(-30, 31);
            this.transform.rotation = Quaternion.Euler(0f, 0f, moveDirect);
            Vector2 rotatedDirection = Quaternion.Euler(0f, 0f, moveDirect) * Vector2.down;
            rigid.velocity = rotatedDirection * speed;
        }
        if (Direction == "Right")
        {
            float moveDirect = Random.Range(-40, -101);
            this.transform.rotation = Quaternion.Euler(0f, 0f, moveDirect);
            Vector2 rotatedDirection = Quaternion.Euler(0f, 0f, moveDirect) * Vector2.down;
            rigid.velocity = rotatedDirection * speed;
        }
        if (Direction == "Left")
        {
            float moveDirect = Random.Range(40, 101);
            this.transform.rotation = Quaternion.Euler(0f, 0f, moveDirect);
            Vector2 rotatedDirection = Quaternion.Euler(0f, 0f, moveDirect) * Vector2.down;
            rigid.velocity = rotatedDirection * speed;
        }

        

        
    }
    void OnHit(int dmg)
    {
        health -= dmg;
        if (Level == 10)
        {
            anim.SetTrigger("OnHit");
        }
        else
        {
            spriteRenderer.sprite = sprites[1];
            Invoke("Resetsprite", 0.05f);
        }
        spriteRenderer.sprite = sprites[1];
        Invoke("Resetsprite", 0.05f);
        if (health <= 0) {

            UIManager.GetComponent<UI>().score += score;   
            Destroy(gameObject);
        }
    }
    void Resetsprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall" && Level != 10) 
        {
            NameOfItem.CurPain += dmg/2;
            Destroy(gameObject);
        }
        else if (collision.tag == "PlayerBullet")
        {
            BulletController bullet = collision.GetComponent<BulletController>();
            Destroy(collision.gameObject);
            OnHit(bullet.dmg);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   

        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
