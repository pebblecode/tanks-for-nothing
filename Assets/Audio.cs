using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	public AudioSource fireAudioSource;
	public AudioClip fire;
	public AudioSource engineAudioSource;
	public AudioClip idle;
	public AudioClip driving;
	private float lastShot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var player = GetComponent<PlayerController> ();
		if (player.rightTrigger > 0.5 && lastShot + 0.3 < Time.time) {
			lastShot = Time.time;
			fireAudioSource.clip = fire;
			fireAudioSource.Play();
		}

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
