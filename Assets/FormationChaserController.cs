﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationChaserController : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
    public float chaseSpeed;
    private Rigidbody2D rigidbody;
    private float maxSpeed = 8;
    private float leftConstraint, rightConstraint = 0.0f;
    private float buffer = 1.0f;
    private float distanceZ = 10.0f;
    private bool moveRight, moveLeft;
    //bool para controlar cuando está moviendose.

    void Awake()
    {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        print(rightConstraint);
    }

    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(target.transform.position.x > 0)
        {
            Vector2 movement = new Vector2(1, -0f);
            rigidbody.AddForce(movement * chaseSpeed * Time.deltaTime);
       
            if (transform.position.x > rightConstraint + buffer)
            { 
                Vector2 movement2 = new Vector2(-1, -0f);
                rigidbody.AddForce(movement2 * 800 * Time.deltaTime);
            }

            if (transform.position.x < leftConstraint - buffer)
            {
                
                Vector2 movement2 = new Vector2(1, -0f);
                rigidbody.AddForce(movement2 * 800 * Time.deltaTime);
            }
        }
        else
        {
            Vector2 movement = new Vector2(-1, -0f);
            rigidbody.AddForce(movement * chaseSpeed * Time.deltaTime);
            if (transform.position.x > rightConstraint + buffer)
            {

                Vector2 movement2 = new Vector2(-1, -0f);
                rigidbody.AddForce(movement2 * 800 * Time.deltaTime);
            }

            if (transform.position.x < leftConstraint - buffer)
            {

                Vector2 movement2 = new Vector2(1, -0f);
                rigidbody.AddForce(movement2 * 800 * Time.deltaTime);
            }
        }

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

    }
}
