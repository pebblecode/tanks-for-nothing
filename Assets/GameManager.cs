using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var controllers = Input.GetJoystickNames ();

		int i = 1;
		foreach (var controller in controllers) {
			var resource = Resources.Load<GameObject>("Player");
			var playerClone = (GameObject)Instantiate(resource, new Vector3(2*i,2,1), new Quaternion());
			var pc = playerClone.GetComponent<PlayerController> ();
			pc.playerNumber = i;
			++i;
		}
			
	}
}
