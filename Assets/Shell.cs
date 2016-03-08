using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	public GameObject owner;
	public float created;
	// Use this for initialization
	void Start () {
		created = Time.time;
	}

}
