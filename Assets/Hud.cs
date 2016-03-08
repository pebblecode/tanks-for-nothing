using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Linq;

public class Hud : MonoBehaviour
{

	public Text score;

	public GameObject[] players;

	public UnityEngine.UI.Text[] scores;
	public UnityEngine.UI.Text winner;
	// Use this for initialization
	void Start ()
	{
		var children = GetComponentsInChildren<UnityEngine.UI.Text> ();
		scores = children.Where(s => s.name.Contains("Score")).ToArray();
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
			scores [pi].gameObject.SetActive (true);
			scores [pi].text = string.Format("Health: {0}\nAmmo: {1}\n", 
				Mathf.Ceil(health.health), health.ammo);
			scores [pi].color = playerController.tankColour;
		}

		if (players.Length == 1 && winner != null) {
			Debug.Log ("One player");
			var playerController = players[0].GetComponent<PlayerController> ();
			winner.color = playerController.tankColour;
			winner.text = string.Format ("Player {0} Wins!", playerController.playerNumber);
		} else
			winner.text = "";
	}
}
