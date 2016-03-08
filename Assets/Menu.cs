using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

  Timer tmr = new Timer(1000);

  // Use this for initialization
  void Start () {
    // tmr.Interval = 1000; // 0.1 second
    // tmr.Elapsed += timerHandler; // We'll write it in a bit
    // tmr.Start(); // The countdown is launched!
  }

  // private void timerHandler (object sender, ElapsedEventArgs e) {
  //   var thisText = GetComponent<Text> ();
  //   thisText.text = "Tanks";
  //   tmr.Stop();
  // }
	
	// Update is called once per frame
	void Update () {
	
	}
}
  