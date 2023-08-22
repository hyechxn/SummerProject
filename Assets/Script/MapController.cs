using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -300));
    }

    void Update()
    {
        if(transform.position.y <= -14f)
        {
            transform.position = new Vector3(0f, 17f, 0f);
        }
    }
}
