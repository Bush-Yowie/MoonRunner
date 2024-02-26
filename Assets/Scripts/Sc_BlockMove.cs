using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_BlockMove : MonoBehaviour
{
    Rigidbody RB;
    public float TimeAlive = 1f;
    public float speed = 1f;
    GameObject block;
    void Start()
    {
        // gets Rigidbody Component
        RB = GetComponent<Rigidbody>();
        block = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = Vector3.left * speed;
        if (TimeAlive <= 0) { Destroy(gameObject); } else
        {
            TimeAlive -= Time.deltaTime;
        }
    }
}
