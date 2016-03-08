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
	}
}
