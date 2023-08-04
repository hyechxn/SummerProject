using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController: MonoBehaviour
{
    private int BulletSpeed;
    public GameObject Bullet;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000) );
        Destroy(Bullet, 1f);
    }
}
