using UnityEngine;
using System.Collections;

public class OpenRDoor : MonoBehaviour {

	public bool opened = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.localPosition; //位置を保持
		Vector3 rotation = transform.localRotation.eulerAngles; //角度を保持
		if(opened == true) { //開けられたら
			position.x = -50f;
			position.z = 0f;
			rotation.y = 180f; 
		}else{
			position.x = -25f;
			position.z = 25f;
			rotation.y = 270f;
		}
		transform.localPosition = position; //位置を更新
		transform.localRotation = Quaternion.Euler(rotation); //角度を更新
	}
}
