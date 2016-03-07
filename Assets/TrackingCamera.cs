using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TrackingCamera : MonoBehaviour {
	public static List<GameObject> players = new List<GameObject>();
	public float angle = 1.0f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		var center = new Vector3(0, 0, 0);
		foreach (var player in players) {
			center += player.transform.position;
		}

		center /= players.Count;
	
		if (players.Count > 0) {
			var h = players.Select(p => (p.transform.position - center).magnitude / Mathf.Tan(angle)).Max();
			h = Mathf.Max (h, 5);
			h = Mathf.Min (h, 40);
			var transform = GetComponent<Transform> ();

			transform.position = new Vector3 (0, h, -h*Mathf.Tan(0.34f)) + center;
		}
	}
}
