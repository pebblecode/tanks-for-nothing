using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	public AudioSource fireAudioSource;
	public AudioClip [] fire;
	public AudioSource engineAudioSource;
	public AudioClip idle;
	public AudioClip driving;
	private float lastShot;
	private PlayerController _player;
	private PlayerController player { 
		get {
			if (_player == null) {
				_player = GetComponent<PlayerController> ();
			}
			return _player;
		}
	}

	public void Fire() {
		fireAudioSource.clip = fire[player.playerNumber];
		fireAudioSource.Play();		
	}

	public void Update () {

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
