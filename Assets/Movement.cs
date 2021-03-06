﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float distToGround;
	public bool isGrounded;
	public int speedMultiplier;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		var playerController = GetComponent<PlayerController> ();

		distToGround = (playerController.GetComponent<Collider>().bounds.extents.y + 0.1f);
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);

		var rb = GetComponent<Rigidbody> ();

		var movement = new Vector3 (playerController.leftStick.x, 0, -playerController.leftStick.z);

		speedMultiplier = 30;

		if (isGrounded) {

			speedMultiplier = 25;

			if (movement.sqrMagnitude > 0.1)
				transform.rotation = Quaternion.LookRotation(movement);
		
			if (playerController.aButton) {
				rb.AddForce(new Vector3(0, 100, 0) * 25);
			}
		}

		rb.AddForce (movement * 40);	

		var turret = transform.Find("Tank/TankRenderers/TankTurret");

		if (playerController.rightStick.sqrMagnitude > 0.1) {
			//Debug.Log(string.Format("Right: x= {0} z={1} ", playerController.rightStick.x, playerController.rightStick.z));
			var dir =  new Vector3(playerController.rightStick.x, 0, -playerController.rightStick.z);
			turret.rotation = Quaternion.LookRotation (dir);
		}

	}
}
