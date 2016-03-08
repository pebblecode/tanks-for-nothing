﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float distToGround;
	public bool isGrounded;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		var playerController = GetComponent<PlayerController> ();

		distToGround = (playerController.GetComponent<Collider>().bounds.extents.y + 0.1f);
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);

		var rb = GetComponent<Rigidbody> ();

		var movement = new Vector3 (playerController.leftStick.x, playerController.leftStick.y, -playerController.leftStick.z);
		rb.AddForce (movement * 30);	

		if (movement.sqrMagnitude > 0.1)
			transform.rotation = Quaternion.LookRotation(movement);
		
		if (isGrounded) {
			if (playerController.aButton) {
				rb.AddForce(new Vector3(0, 100, 0) * 10);
			}
		}
	}
}
