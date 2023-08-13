using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController: MonoBehaviour
{
    private int BulletSpeed=1000;
    public GameObject Bullet;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up* BulletSpeed);
        Destroy(Bullet, 0.5f);
    }
    void Update()
    {
        if (gameObject.name == "BulletLv1(Clone)")
            Debug.Log("ÀÌÀ×");
    }
}
