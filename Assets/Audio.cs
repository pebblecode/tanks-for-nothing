using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	public AudioSource audioSource;
	public AudioClip idle;
	public AudioClip driving;
	public AudioClip shotCharging;
	public AudioClip fire;
	public AudioClip shellExplosion;
	private float lastShot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var player = GetComponent<PlayerController> ();
		if (player.rightTrigger > 0.5 && lastShot + 0.3 < Time.time) {
			lastShot = Time.time;
			audioSource.clip = fire;
			audioSource.Play();
		}
	}
}
