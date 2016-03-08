using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float terminalVelocity = 10;
	public float maxAcceleration = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		var playerController = GetComponent<PlayerController> ();
		var movement = new Vector3 (playerController.leftStick.x, playerController.leftStick.y, -playerController.leftStick.z);
		var rb = GetComponent<Rigidbody> ();

		rb.AddForce (movement * 10);
		//var idealDrag = maxAcceleration / terminalVelocity;
		//rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);

		//var trans = GetComponent<Transform> ();
		transform.rotation = Quaternion.LookRotation(movement);
	}
}
