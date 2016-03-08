using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class Hud : MonoBehaviour
{

	public Text score;

	public GameObject[] players;

	// Use this for initialization
	void Start ()
	{
		score = GetComponent<UnityEngine.UI.Text> ();
		score.text = "WOAH";


	}
	
	// Update is called once per frame
	void Update ()
	{
		players = GameObject.FindGameObjectsWithTag ("Player");

		var sb = new System.Text.StringBuilder ();
		foreach (var player in players) {
			var playerController = player.GetComponent<PlayerController> ();
			var health = player.GetComponent<TankHealth> ();
			sb.AppendFormat("{0}: Health {1} Ammo {2}\n", playerController.playerNumber, Mathf.Ceil(health.health), health.ammo);
		}
		score.text = sb.ToString ();
	}
}
