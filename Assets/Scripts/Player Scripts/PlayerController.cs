using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int shipSpeed;
    private Rigidbody2D rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        float inputAxis = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(inputAxis, 0);
        rigidbody.AddForce(movement * shipSpeed * Time.deltaTime);
	}
}
