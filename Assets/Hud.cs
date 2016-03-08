using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class Hud : MonoBehaviour
{

	public Text score;

	public GameObject[] players;

	public UnityEngine.UI.Text[] scores;
	// Use this for initialization
	void Start ()
	{
		//score = GetComponent<UnityEngine.UI.Text> ();
		//score.text = "WOAH";

		scores = GetComponentsInChildren<UnityEngine.UI.Text> ();
		foreach (var s in scores) {
			s.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (var player in players) {
			var playerController = player.GetComponent<PlayerController> ();
			var health = player.GetComponent<TankHealth> ();
			var pi = playerController.playerNumber - 1;
			scores[pi].text = string.Format("Health: {0}\nAmmo: {1}\n", 
				Mathf.Ceil(health.health), health.ammo);
			scores [pi].color = playerController.tankColour;
			scores [pi].gameObject.SetActive (true);
		}

		/*players = GameObject.FindGameObjectsWithTag ("Player");

		var sb = new System.Text.StringBuilder ();
		foreach (var player in players) {
			var playerController = player.GetComponent<PlayerController> ();
			var health = player.GetComponent<TankHealth> ();
			if (playerController != null && health != null)
				sb.AppendFormat("{0}: Health {1} Ammo {2}\n", playerController.playerNumber, Mathf.Ceil(health.health), health.ammo);
		}
		score.text = sb.ToString ();*/
	}
}
