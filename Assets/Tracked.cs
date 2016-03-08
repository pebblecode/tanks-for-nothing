using UnityEngine;
using System.Collections;

public class Tracked : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TrackingCamera.players.Add(this.gameObject);	
	}

	void OnDestroy () {
		TrackingCamera.players.Remove(this.gameObject);
	}
}
