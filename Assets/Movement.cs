using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		var playerController = GetComponent<PlayerController> ();
		var movement = new Vector3 (playerController.leftStick.x, playerController.leftStick.y, -playerController.leftStick.z);
		var rb = GetComponent<Rigidbody> ();

		rb.AddForce (movement * 10);

		if (movement.sqrMagnitude > 0.1)
			transform.rotation = Quaternion.LookRotation(movement);

		var turret = transform.Find("Tank/TankRenderers/TankTurret");

		if (playerController.rightStick.sqrMagnitude > 0.1) {
			//Debug.Log(string.Format("Right: x= {0} z={1} ", playerController.rightStick.x, playerController.rightStick.z));
			var dir =  new Vector3(playerController.rightStick.x, 0, -playerController.rightStick.z);
			turret.rotation = Quaternion.LookRotation (dir);
		}
	}
}
