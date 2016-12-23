﻿using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

    public Rigidbody rb;
    public float acceleration;
    public float currentAccel;
    private bool grounded;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            currentAccel = acceleration;
        }
        else
        {
            currentAccel = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, transform.up, -5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, transform.up, 5);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded) {
                rb.AddForce(transform.up * 10, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        grounded = false;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * currentAccel, ForceMode.Acceleration);
    }
} 
