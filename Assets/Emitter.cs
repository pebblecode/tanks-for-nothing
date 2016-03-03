using UnityEngine;
using System.Collections;




public class Emitter : MonoBehaviour {

	float fireTime;
	public float fireRate = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && fireTime + fireRate < Time.time) {	
			fireTime = Time.time;
			var res = Resources.Load<Object>("projectile");
			var clone = (GameObject)Instantiate(res, transform.position + new Vector3(0,1,0.5f), new Quaternion());
			var bomb = clone.gameObject.GetComponent<Bomb> ();
			bomb.owner = gameObject;
			var rb = clone.GetComponent<Rigidbody>();
			var forward = new Vector3 (0, 0, 100);
			rb.AddForce(forward);
		}
	}
}
