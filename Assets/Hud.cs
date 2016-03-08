using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

  public Text score;

	// Use this for initialization
	void Start () {
    score = GetComponent<UnityEngine.UI.Text> ();
    score.text = "WOAH";
	}
	
	// Update is called once per frame
	void Update () {
    var playerController = GetComponent<PlayerController> ();
    if (playerController != null){
      score.text = string.Format("{0}", playerController.ballCount);
    }
	}
}
