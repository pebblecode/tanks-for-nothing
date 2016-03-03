using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float terminalVelocity = 10;
	public float maxAcceleration = 1000;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var moveHorizontal = Input.GetAxis ("Horizontal");
		var moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		var rb = GetComponent<Rigidbody> ();

		rb.AddForce (movement * 1000);

		var idealDrag = maxAcceleration / terminalVelocity;
		rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);

		// TODO: restrict x,y,z
	}
}
