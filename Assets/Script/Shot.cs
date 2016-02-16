using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public GameObject bullet;
	public Transform spawn;
	public float speed = 1000f;
	private float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	void Shoot() {
		if(Input.GetButtonDown("Fire2")) {
			GameObject obj = GameObject.Instantiate(bullet)as GameObject;
			obj.transform.position = spawn.position;
			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			obj.GetComponent<Rigidbody>().AddForce(force);
			Object.Destroy (obj, 5f);
		}
	}
}
