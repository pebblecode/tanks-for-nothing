using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float life = 3;
	float created; 

	public GameObject owner;

	void Start () {
		created = Time.time;
	}
	
	void Update () {
		if (created + life < Time.time) {
			Destroy (gameObject);
		}	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject != owner) {
			Debug.Log ("Collided with " + collision.gameObject.name);
			Destroy (gameObject);
		}
	}
}
