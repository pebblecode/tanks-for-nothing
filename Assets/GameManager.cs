using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Color[] tankColours = new Color[]
	{   new Color(0,0,0),
		new Color(0.1f,0.5f,0.2f),
		new Color(0.5f,0.1f,0.2f),
		new Color(0.5f,0,0),
		new Color(0,0.5f,0.5f)};
	
	// Use this for initialization
	void Start () {
		var controllers = Input.GetJoystickNames ();

		int i = 1;
		foreach (var _ in controllers) {
			var resource = Resources.Load<GameObject>("Player");
			var playerClone = (GameObject)Instantiate(resource, new Vector3(2*i,2,1), new Quaternion());
			var pc = playerClone.GetComponent<PlayerController> ();
			pc.playerNumber = i;
			pc.tankColour = tankColours[i];
			++i;
		}



			
	}
}
