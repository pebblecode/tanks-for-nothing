﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Color[] tankColours = new Color[]
	{   new Color(0,0,0),
		new Color(0.1f,0.5f,0.2f),
		new Color(0.5f,0.1f,0.2f),
		new Color(0.5f,0,0),
		new Color(0,0.5f,0.5f)};
	

	public GameObject pickup;
	public GameObject badPickup;
	public Vector3 spawnValues;
	public int pickupCount;
	public int badPickupCount;
	public int goalCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public AudioSource music;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
		var controllers = Input.GetJoystickNames ();
		var resource = Resources.Load<GameObject>("Player");

		for (int i = 1; i <= controllers.Length; ++i) {
			var playerClone = (GameObject)Instantiate(resource, new Vector3(5*i,0,1), new Quaternion());
			var pc = playerClone.GetComponent<PlayerController> ();
			pc.playerNumber = i;
			pc.tankColour = tankColours[i];
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		{
			for (int i = 0; i < pickupCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (pickup, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i < badPickupCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (badPickup, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			//yield return new WaitForSeconds (waveWait);
		}
	}

}
