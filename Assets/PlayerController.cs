using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int playerNumber = 0;

	public Vector3 leftStick;
	public Vector3 rightStick;
	public float leftTrigger;
	public float rightTrigger;
	public Color tankColour;
	public Text countText;
	public bool aButton;

	private int ballCount;


	// Use this for initialization
	void Start () {
		MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer> ();

		// Go through all the renderers...
		for (int i = 0; i < renderers.Length; i++)
		{
			// ... set their material color to the color specific to this tank.
			renderers[i].material.color = tankColour;
		}
		ballCount = 0;
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () {
		var i = playerNumber;
		leftStick = new Vector3 (Input.GetAxis ("L_XAxis_"+i), 0, Input.GetAxis ("L_YAxis_"+i));
		rightStick = new Vector3 (Input.GetAxis ("R_XAxis_"+i), 0, Input.GetAxis ("R_YAxis_"+i));
		leftTrigger = Input.GetAxis ("TriggersL_"+i);
		rightTrigger = Input.GetAxis ("TriggersR_"+i);
		aButton = Input.GetButtonDown ("A_"+i);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			Destroy (other.gameObject.GetComponent<Rigidbody>());
			other.gameObject.SetActive (false);
			ballCount = ballCount + 1;
			SetCountText ();
		}
		// if (other.gameObject.CompareTag ("Bad Pickup")) {
		// 	other.gameObject.SetActive (false);
		// }
		// if (other.gameObject.CompareTag ("Goal")) {
		// }

	}

	void SetCountText ()
	{
		//countText.text = "Count: " + ballCount.ToString ();
	}
}
