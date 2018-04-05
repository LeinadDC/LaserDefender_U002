using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int shipSpeed;
    private Rigidbody2D rigidbody;
    private float maxSpeed = 8;
    private float leftConstraint, rightConstraint = 0.0f;
    private float buffer = 1.0f;
    private float distanceZ = 10.0f;

    void Awake()
    {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
    }


    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        float inputAxis = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(inputAxis, 0f);
        rigidbody.AddForce(movement * shipSpeed * Time.deltaTime);
        
        if(rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        if(transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector2(rightConstraint + buffer, transform.position.y);
        }

        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector2(leftConstraint - buffer, transform.position.y);
        }
    }
}
