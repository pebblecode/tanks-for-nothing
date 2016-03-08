using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerNumber = 0;

	public Vector3 leftStick;
	public Vector3 rightStick;
	public float leftTrigger;
	public float rightTrigger;

	public Color[] xxx = new Color[]
	{   new Color(0,0,0),
		new Color(0.5f,0,0.5f,1.0f),
		new Color(0,0,0.5f),
		new Color(0.5f,0,0),
		new Color(0,0.5f,0.5f)};

	// Use this for initialization
	void Start () {
		MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer> ();

		// Go through all the renderers...
		for (int i = 0; i < renderers.Length; i++)
		{
			// ... set their material color to the color specific to this tank.
			renderers[i].material.color = xxx[playerNumber];
		}
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
