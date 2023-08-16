using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController: MonoBehaviour
{
    private int BulletSpeed=1000;
    public GameObject Bullet;
    public int dmg;
    public int bulletLevel;
    void Awake()
    {
        if (this.tag =="PlayerBullet")
        {

        
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * BulletSpeed);

            PlayerController player = GetComponentInParent<PlayerController>();
            if (bulletLevel == 1)
            {
                dmg = 1;
            }
            else if (bulletLevel == 2)
            {
                dmg = 2;
            }
            else if (bulletLevel == 3)
            {
                dmg = 3;
            }
        }
        if (this.tag == "EnemyBullet")
        {
            
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * BulletSpeed);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.tag == "Wall") 
                        Destroy(Bullet);
    }
    private void OnTriggerrEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "EnemyBullet"&& collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
