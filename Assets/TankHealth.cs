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
		if (collision.gameObject.name.Contains ("Shell") && 
			collision.gameObject.GetComponent<Shell>().owner != gameObject &&
			collision.relativeVelocity.sqrMagnitude > 1000)
		{
			health -= (collision.relativeVelocity.sqrMagnitude/220.0f);
			Debug.Log ("Hit: " + health);
			if (health < 0) {
				Debug.Log ("Dead");
				Destroy (gameObject);
			}
		}

		if (collision.relativeVelocity.sqrMagnitude < 1000 && 
			collision.gameObject.name.Contains ("Shell")) {
			ammo += 1;
			Destroy (collision.gameObject);
		}
	}

}
