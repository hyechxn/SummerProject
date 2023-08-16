using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string[] type;
    Rigidbody2D rigid;
    public string thisType;
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
}
