using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public bool opened = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.localPosition; //位置を保持
		Vector3 rotation = transform.localRotation.eulerAngles; //角度を保持
		if(opened == true) { //開けられたら
			position.x = 2.5f;
			position.y = -1.4f;
			position.z = 1.05f;
			rotation.z = 70f; 
		}else{
			position.x = 1.49f;
			position.y = 0.01f;
			position.z = 1.05f;
			rotation.z = 0f;
		}
		transform.localPosition = position; //位置を更新
		transform.localRotation = Quaternion.Euler(rotation); //角度を更新
	}
}
