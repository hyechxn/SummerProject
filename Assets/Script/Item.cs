using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string[] type;
    Rigidbody2D rigid;
    public string thisType;

    public GameObject item;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 3f;
        if (gameObject.tag == "Item")
        {
            int RandomItem = Random.Range(0, 4);
            thisType = type[RandomItem];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.tag == "ItemSpawn")
        {
            if (collision.tag == "PlayerBullet")
            {
                Instantiate(item, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
