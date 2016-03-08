using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerNumber = 0;

	public Vector3 leftStick;
	public Vector3 rightStick;
	public float leftTrigger;
	public float rightTrigger;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var i = playerNumber;
		leftStick = new Vector3 (Input.GetAxis ("L_XAxis_"+i), 0, Input.GetAxis ("L_YAxis_"+i));
		rightStick = new Vector3 (Input.GetAxis ("R_XAxis_"+i), 0, Input.GetAxis ("R_YAxis_"+i));
		leftTrigger = Input.GetAxis ("TriggersL_"+i);
		rightTrigger = Input.GetAxis ("TriggersR_"+i);
	}
}
