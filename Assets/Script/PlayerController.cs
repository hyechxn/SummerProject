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

    public int HP;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPosition = transform.position;
    }

    void Update()
    {

        playerPosition.x = Time.deltaTime * moveSpeed * Input.GetAxis("Horizontal");
        if(Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.sprite = Move[2];
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.sprite = Move[1];
        }
        else
        {
            spriteRenderer.sprite = Move[0];
        }
        playerPosition.y = Time.deltaTime * moveSpeed * Input.GetAxis("Vertical");

        transform.Translate(playerPosition);

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

    
}
