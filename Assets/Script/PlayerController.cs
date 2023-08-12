using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 playerPosition;
    private float moveSpeed = 8f;
    private SpriteRenderer spriteRenderer;
    public int bulletLevel = 3;

    public GameObject bulletS;
    public GameObject bulletM;
    public GameObject bulletL;


    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchLeft;
    private bool isTouchRight;
    private float h;
    private float v;

    public int HP;

    private Animator anim;

    private bool isFire;
    private float delayTime = 0.1f;
    private float delay;
    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPosition = transform.position;
    }

    void Update()
    {
        Move();
        Fire();
    }
    void Move()
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

            Vector3 movement = new Vector3(h, v, 0) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

        if ((Input.GetButtonDown("Horizontal")) || (Input.GetButtonUp("Horizontal")))
        {
            anim.SetInteger("Input", (int)h);
        }
    }
    void Fire()
{
        if (isFire == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (bulletLevel == 1)
                {
                    Instantiate(bulletS, transform.position, transform.rotation);
                }
                else if (bulletLevel == 2)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 0.25f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 0.25f, transform.rotation);
                }
                else if (bulletLevel == 3)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 0.5f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 0.5f, transform.rotation);
                    Instantiate(bulletM, transform.position + Vector3.up *0.3f, transform.rotation);
                }
                else if (bulletLevel == 4)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 0.5f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 0.5f, transform.rotation);
                    Instantiate(bulletL, transform.position + Vector3.up * 0.3f, transform.rotation);
                }
                else if (bulletLevel >= 5)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 1f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 1f, transform.rotation);
                    Instantiate(bulletM, transform.position + Vector3.right * 0.5f + Vector3.up * 0.3f, transform.rotation);
                    Instantiate(bulletM, transform.position + Vector3.left * 0.5f + Vector3.up * 0.3f, transform.rotation);
                    Instantiate(bulletL, transform.position + Vector3.up * 0.6f, transform.rotation);
                }

                isFire = true;
            }
        }
        if (isFire == true)
        {
            delay+= Time.deltaTime;
        }
        if (delayTime <= delay)
        {
            isFire = false;
            delay= 0f;
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
