using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuItem : MonoBehaviour {

	public void OnClick() {
		Debug.Log ("Clicked");
		SceneManager.LoadScene ("Arena");
	}
}
