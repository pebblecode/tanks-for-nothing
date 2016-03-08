using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

  Timer tmr = new Timer(1000);
  public float spawnWait;
  public float startWait;
  public float waveWait;
  public int tankCount;
  public GameObject bouncyTank;
  public Vector3 spawnValues;

  // Use this for initialization
  void Start () {
    StartCoroutine (SpawnWaves ());
    // tmr.Interval = 1000; // 0.1 second
    // tmr.Elapsed += timerHandler; // We'll write it in a bit
    // tmr.Start(); // The countdown is launched!
  }

  // private void timerHandler (object sender, ElapsedEventArgs e) {
  //   var thisText = GetComponent<Text> ();
  //   thisText.text = "Tanks";
  //   tmr.Stop();
  // }

  IEnumerator SpawnWaves ()
  {
    yield return new WaitForSeconds (startWait);
    {
      for (int i = 0; i < tankCount; i++)
      {
        Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate (bouncyTank, spawnPosition, spawnRotation);
        yield return new WaitForSeconds (spawnWait);
      }
      //yield return new WaitForSeconds (waveWait);
    }
  }
	
	// Update is called once per frame
	void Update () {
	
	}
}
  