using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{ 
    public GameObject gameManager;
    public GameManager gm;
    public GameObject uiManager;
    public UI um;
    void Start()
    {
        um = uiManager.GetComponent<UI>();
        gm = gameManager.GetComponent<GameManager>();
        if (gameObject.tag == "BackGround")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -300));
        }
        if (gameObject.tag == "Fade")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(300,0));
        }
    }

    void Update()
    {
        if (gameObject.tag == "BackGround")
        {
            if (transform.position.y <= -14f)
            {
                transform.position = new Vector3(0f, 17f, 0f);
            }
        }
        else if (gameObject.tag == "Fade")
        {
            Invoke("StopFade", 8);
            Invoke("GoStage2", 3);
        }
    }
    void StopFade()
    {
        //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.SetActive(false);
        gm.isBoss = false;
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(300,0));
    }
    void GoStage2() 
    {
        gm.Stage = 2;
        um.CurHp = 200;
        um.CurPain = 90;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "haha")
        {
            gameObject.SetActive(false);
        }

    }
  }

