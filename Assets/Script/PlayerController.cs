using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 playerPosition;
    private float moveSpeed = 8f;
    public Sprite[] Move;
    private SpriteRenderer spriteRenderer;
    public int bulletLevel = 3;

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;


    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchLeft;
    private bool isTouchRight;
    private float h;
    private float v;

    public int HP;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPosition = transform.position;
    }

    void Update()
    {   
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        

        
        if ((isTouchLeft &&  h == -1) || (isTouchRight && h==1))
        {
            h = 0;
        }
        
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

           
        if(h < 0)
            {
                spriteRenderer.sprite = Move[2];
            }
        else if (h > 0)
            {
                spriteRenderer.sprite = Move[1];
            }
            else
            {
                spriteRenderer.sprite = Move[0];
            }

        Vector3 movement = new Vector3(h, v, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        if (Input.GetButtonDown("Fire1"))
            {
                if (bulletLevel == 1)
                {
                    Instantiate(bullet1, transform.position, transform.rotation);
                }
                else if (bulletLevel == 2)
                {
                    Instantiate(bullet2, transform.position, transform.rotation);
                }
                else if (bulletLevel == 3)
                {
                    Instantiate(bullet3, transform.position, transform.rotation);
                }
                else if (bulletLevel == 4)
                {
                    Instantiate(bullet4, transform.position, transform.rotation);
                }
                else if (bulletLevel >= 5)
                {
                    Instantiate(bullet5, transform.position, transform.rotation);
                }
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            switch(other.gameObject.name) {
                case "Top":
                    isTouchTop = true; 
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }
}
