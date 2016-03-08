using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


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
	public float restartTimer;

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

		CreateLevel ();
	}

	void Update() {
		var players = GameObject.FindGameObjectsWithTag ("Player");
		if (players.Length == 1 && restartTimer == 0) {
			restartTimer = Time.time + 30;
		}
		if (players.Length == 1 && restartTimer != 0 && restartTimer < Time.time) {
			SceneManager.LoadScene ("Arena");
		}
	}

	Vector3 PointInLevel()
	{
		return new Vector3(Random.Range(-40.0f, 40.0f), 0, Random.Range(-40.0f, 40.0f));
	}

	Vector3 RandomDirection()
	{
		return new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
	}

	string[] duneResources = new string[] {
		"Dune1",
		"Dune2",
		"Concrete",
		"Crater01"
	};
		
	string[] treeResources = new string[] {
		"Cactus",
		"Tree",
		"PalmTree"
	};


	void CreateLevel ()
	{
		// Dunes
		for (int i = 0; i < 20; ++i) {
			var resource = Resources.Load (duneResources [Random.Range (0, duneResources.Length)]);
			Instantiate(resource, PointInLevel(), Quaternion.LookRotation(RandomDirection()));
		}

		// Tree
		for (int i = 0; i < 10; ++i) {
			var resource = Resources.Load (treeResources [Random.Range (0, treeResources.Length)]);
			Instantiate(resource, PointInLevel(), Quaternion.LookRotation(RandomDirection()));
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
