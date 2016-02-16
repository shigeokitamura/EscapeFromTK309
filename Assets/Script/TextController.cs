using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public float timer = 0f;

	public bool key = true;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "";
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5) {
			GetComponent<Text> ().text = "";
		}
	}

	public void drawText(string txt) {
		GetComponent<Text> ().text = txt;
		timer = 0;
	}

	public void inputDial() {
		StartCoroutine (waitKey ());
	}

	IEnumerator waitKey() {
		timer = -1000;
		string txt = "開かない。よく見るとダイヤルロックが掛かっている。" + System.Environment.NewLine;
		int[] num = new int[4]; 
		GetComponent<Text> ().text = txt + "_ _ _ _";
		yield return new WaitForSeconds (0.5f);
		while (!Input.anyKeyDown) {
			yield return 0;
		}
		if(Input.GetKey(KeyCode.Alpha0)) {
			num [0] = 0;
		}else if(Input.GetKey(KeyCode.Alpha1)) {
			num [0] = 1;
		}else if(Input.GetKey(KeyCode.Alpha2)) {
			num [0] = 2;
		}else if(Input.GetKey(KeyCode.Alpha3)) {
			num [0] = 3;
		}else if(Input.GetKey(KeyCode.Alpha4)) {
			num [0] = 4;
		}else if(Input.GetKey(KeyCode.Alpha5)) {
			num [0] = 5;
		}else if(Input.GetKey(KeyCode.Alpha6)) {
			num [0] = 6;
		}else if(Input.GetKey(KeyCode.Alpha7)) {
			num [0] = 7;
		}else if(Input.GetKey(KeyCode.Alpha8)) {
			num [0] = 8;
		}else if(Input.GetKey(KeyCode.Alpha9)) {
			num [0] = 9;
		}
		GetComponent<Text> ().text = txt + num[0] + " _ _ _";

		yield return new WaitForSeconds (0.5f);
		while (!Input.anyKeyDown) {
			yield return 0;
		}
		if(Input.GetKey(KeyCode.Alpha0)) {
			num [1] = 0;
		}else if(Input.GetKey(KeyCode.Alpha1)) {
			num [1] = 1;
		}else if(Input.GetKey(KeyCode.Alpha2)) {
			num [1] = 2;
		}else if(Input.GetKey(KeyCode.Alpha3)) {
			num [1] = 3;
		}else if(Input.GetKey(KeyCode.Alpha4)) {
			num [1] = 4;
		}else if(Input.GetKey(KeyCode.Alpha5)) {
			num [1] = 5;
		}else if(Input.GetKey(KeyCode.Alpha6)) {
			num [1] = 6;
		}else if(Input.GetKey(KeyCode.Alpha7)) {
			num [1] = 7;
		}else if(Input.GetKey(KeyCode.Alpha8)) {
			num [1] = 8;
		}else if(Input.GetKey(KeyCode.Alpha9)) {
			num [1] = 9;
		}
		GetComponent<Text> ().text = txt + num[0] + " " + num[1] + " _ _";

		yield return new WaitForSeconds (0.5f);
		while (!Input.anyKeyDown) {
			yield return 0;
		}
		if(Input.GetKey(KeyCode.Alpha0)) {
			num [2] = 0;
		}else if(Input.GetKey(KeyCode.Alpha1)) {
			num [2] = 1;
		}else if(Input.GetKey(KeyCode.Alpha2)) {
			num [2] = 2;
		}else if(Input.GetKey(KeyCode.Alpha3)) {
			num [2] = 3;
		}else if(Input.GetKey(KeyCode.Alpha4)) {
			num [2] = 4;
		}else if(Input.GetKey(KeyCode.Alpha5)) {
			num [2] = 5;
		}else if(Input.GetKey(KeyCode.Alpha6)) {
			num [2] = 6;
		}else if(Input.GetKey(KeyCode.Alpha7)) {
			num [2] = 7;
		}else if(Input.GetKey(KeyCode.Alpha8)) {
			num [2] = 8;
		}else if(Input.GetKey(KeyCode.Alpha9)) {
			num [2] = 9;
		}
		GetComponent<Text> ().text = txt + num[0] + " " + num[1] + " " + num[2] + " _";

		yield return new WaitForSeconds (0.5f);
		while (!Input.anyKeyDown) {
			yield return 0;
		}
		if(Input.GetKey(KeyCode.Alpha0)) {
			num [3] = 0;
		}else if(Input.GetKey(KeyCode.Alpha1)) {
			num [3] = 1;
		}else if(Input.GetKey(KeyCode.Alpha2)) {
			num [3] = 2;
		}else if(Input.GetKey(KeyCode.Alpha3)) {
			num [3] = 3;
		}else if(Input.GetKey(KeyCode.Alpha4)) {
			num [3] = 4;
		}else if(Input.GetKey(KeyCode.Alpha5)) {
			num [3] = 5;
		}else if(Input.GetKey(KeyCode.Alpha6)) {
			num [3] = 6;
		}else if(Input.GetKey(KeyCode.Alpha7)) {
			num [3] = 7;
		}else if(Input.GetKey(KeyCode.Alpha8)) {
			num [3] = 8;
		}else if(Input.GetKey(KeyCode.Alpha9)) {
			num [3] = 9;
		}
		GetComponent<Text> ().text = txt + num[0] + " " + num[1] + " " + num[2] + " " + num[3];
		yield return new WaitForSeconds (1f);

		if (num [0] == 1 && num [1] == 5 && num [2] == 1 && num [3] == 0) {
			GetComponent<Text> ().text = "ダイヤルロックが外れた。";
			key = false;
			yield break;
		} else {
			GetComponent<Text> ().text = "番号が違う様だ。";
			key = true;
			yield break;
		}
	}
}
