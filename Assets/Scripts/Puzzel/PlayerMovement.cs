using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float dirX, dirZ;
    public float movespped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirZ = Input.GetAxis("Vertical");

        if (dirZ != 0)
            Rotate();
        if (dirX != 0)
            Move();
    }

    private void Rotate()
    {
        transform.position += transform.forward * dirZ * Time.deltaTime;
    }

    private void Move()
    {
        transform.Rotate(new Vector3(0f, dirX * Time.deltaTime* movespped, 0f));
    }
}
