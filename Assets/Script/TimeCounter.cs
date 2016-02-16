using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	private float minutes = 0f;
	private float seconds = 0f;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "00:00";
	}
	
	// Update is called once per frame
	void Update () {
		seconds += Time.deltaTime;
		if (seconds > 60) {
			minutes += 1f;
			seconds = 0f;
		}
		string timer = "";

		if (minutes < 10) {
			timer += "0";
		}
		timer += minutes.ToString ();

		timer += ":";

		if (seconds < 10) {
			timer += "0";
		}
		timer += ((int)seconds).ToString ();

		GetComponent<Text> ().text = timer;
	}
}
