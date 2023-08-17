using System.Collections;
using System.Collections.Generic;
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

    private float delayTime = 3f;
    private float delay;
    private bool isFire= true;

    public int Level;

    public GameObject player;
    public GameObject Score;
    private int score;
    private float directTime= 1f;
    private float nextTime;

    public int dmg;

    public UI ui;

    public GameObject painBar;
    void Awake()
    {
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
        Score = GameObject.Find("Score Text");
        player = GameObject.Find("Player");
        painBar = GameObject.Find("Pain Bar");
        ui = painBar.GetComponent<UI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }


    void Start()
    {
        RandomDirect();
    }
    void Update()
    {
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

    void RandomDirect()
    {
        float moveDirect = Random.Range(-30, 31);
        this.transform.rotation = Quaternion.Euler(0f, 0f, moveDirect);


        Vector2 rotatedDirection = Quaternion.Euler(0f, 0f, moveDirect) * Vector2.down;

        rigid.velocity = rotatedDirection * speed;
    }
    void OnHit(int dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("Resetsprite", 0.05f);
        if (health <= 0)
        {
            Score.GetComponent<UI>().score += score;   
            Destroy(gameObject);
        }
    }
    void Resetsprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall" ) 
        {
            ui.CurPain += dmg/2;
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
