﻿using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	float lastShot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var playerController = GetComponent<PlayerController> ();
		var audio = GetComponent<Audio> ();
		var turret = transform.Find("Tank/TankRenderers/TankTurret");
		var turretFire = transform.Find("Tank/TankRenderers/TankTurret/Fire");

		var dir =  new Vector3(playerController.rightStick.x, 0, -playerController.rightStick.z);
		if (dir.sqrMagnitude > 0.1) {
			//Debug.Log(string.Format("Right: x= {0} z={1} ", playerController.rightStick.x, playerController.rightStick.z));

			turret.rotation = Quaternion.LookRotation (dir);
		}	

		var health = GetComponent<TankHealth> ();

		if (health.ammo > 0 &&
			playerController.rightTrigger > 0.5 && lastShot + 0.5 < Time.time) {
			audio.Fire ();
			lastShot = Time.time;
			health.ammo -= 1;
			var shell = Resources.Load<GameObject>("Shell");
			var shellInstane = (GameObject)Instantiate(shell, turretFire.position, new Quaternion());
			var shellComponent = shellInstane.GetComponent<Shell> ();
			shellComponent.owner = gameObject;
			var shellRigidbody = shellInstane.GetComponent<Rigidbody> ();
			shellRigidbody.velocity = turret.forward * 60;
			shellRigidbody.rotation = Quaternion.LookRotation (turret.forward);
		}
	}
}
