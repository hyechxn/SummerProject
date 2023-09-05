using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string[] type;
    Rigidbody2D rigid;
    public string thisType;
    public UI um;
    public GameObject item;
    public GameObject UIManager;

    public string Direction;

    void Awake()
    {
        UIManager = GameObject.Find("UI Manager");
        if (UIManager != null)
        {
            um = UIManager.GetComponent<UI>();
        }

        if (gameObject.tag == "Item")
        {
            int RandomItem = Random.Range(0, 5);
            thisType = type[RandomItem];

            rigid = GetComponent<Rigidbody2D>();
            rigid.velocity = Vector2.down * 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "ItemSpawn")
        {
            if (collision.tag == "PlayerBullet"||collision.tag == "Player")
            {
                Instantiate(item, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Mine")
        {
            if (collision.tag == "PlayerBullet"||collision.tag == "Player")
            {
                um.CurPain += 30;
                if(collision.tag == "PlayerBullet")
                    Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
