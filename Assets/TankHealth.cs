using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour {

	public float health = 100;

	public int ammo = 0;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	void OnCollisionEnter(Collision collision) {
		//if (collision.gameObject.GetComponent<Rigidbody>
		if (collision.gameObject.name.Contains ("Shell") && 
			collision.gameObject.GetComponent<Shell>().owner != gameObject &&
			collision.relativeVelocity.sqrMagnitude > 1000)
		{
			Debug.Log ("Hit: " + collision.relativeVelocity.sqrMagnitude);
			health -= (collision.relativeVelocity.sqrMagnitude/360.0f);
			if (health < 0) {
				Debug.Log ("Dead");
			}
		}

		if (collision.relativeVelocity.sqrMagnitude < 1000 && 
			collision.gameObject.name.Contains ("Shell")) {
			Debug.Log ("Collect");
			ammo += 1;

			Destroy (collision.gameObject);
		}
	}

}
