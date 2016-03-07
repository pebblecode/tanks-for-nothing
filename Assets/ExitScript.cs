using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

	public void OnClick() {
		Debug.Log ("exit");
		Application.Quit ();
	}
}
