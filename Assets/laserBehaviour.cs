using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehaviour : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rigidbody;

	void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();	
	}

    void Start()
    {
        rigidbody.velocity = new Vector2(0, 10);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
