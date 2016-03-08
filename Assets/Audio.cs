using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	public AudioSource fireAudioSource;
	public AudioClip fire;
	public AudioSource engineAudioSource;
	public AudioClip idle;
	public AudioClip driving;
	private float lastShot;

	public void Fire() {
		fireAudioSource.clip = fire;
		fireAudioSource.Play();		
	}

	public void Update () {
		var player = GetComponent<PlayerController> ();

		if (player.leftStick.magnitude > 0 && engineAudioSource.clip != driving) { 
			engineAudioSource.clip = driving;
			engineAudioSource.Play ();
		}

		if (player.leftStick.magnitude <= 0 && engineAudioSource.clip != idle) {
			engineAudioSource.clip = idle;
			engineAudioSource.Play ();
		}


	}
}
