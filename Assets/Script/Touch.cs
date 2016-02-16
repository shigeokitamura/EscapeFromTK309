using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	// rayが届く範囲
	public float distance = 20f;

	public GameObject rdoor1;
	public GameObject rdoor2;
	public GameObject door;
	public OpenRDoor openrdoor;
	public OpenDoor opendoor;
	public TextController textcontroller;

	private GameObject[] lights = new GameObject[7];
	private bool lightIsOn = true;
	private bool curtainClosed = false;
	private bool refLocked = true;
	private bool numberSaw = false;
	private bool cardGot = false;

	void Awake() {
		lights [0] = GameObject.Find ("Point light1");
		lights [1] = GameObject.Find ("Point light2");
		lights [2] = GameObject.Find ("Point light3");
		lights [3] = GameObject.Find ("Point light4");
		lights [4] = GameObject.Find ("Point light5");
		lights [5] = GameObject.Find ("Point light6");
		lights [6] = GameObject.Find ("Directional light");
	}

	// Use this for initialization
	void Start() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {
		// 左クリックを取得
		if(Input.GetButtonDown("Fire1")) {
			// クリックしたスクリーン座標をrayに変換
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// Rayの当たったオブジェクトの情報を格納する
			RaycastHit hit = new RaycastHit();
			// オブジェクトにrayが当たった時
			if(Physics.Raycast(ray, out hit, distance)) {
				// rayが当たったオブジェクトの名前を取得
				string objectName = hit.collider.gameObject.name;
				string objectName2 = hit.collider.gameObject.transform.parent.name;
				Debug.Log(objectName);

				if (objectName == "RDoor1") {
					if (numberSaw == false) {
						textcontroller.drawText ("開かない。よく見るとダイヤルロックが掛かっている。");
					} else if (refLocked == true) {
						textcontroller.inputDial ();
						Debug.Log (textcontroller.key);
						refLocked = false;
					} else if(refLocked == false) {
						openrdoor = rdoor1.GetComponent<OpenRDoor> ();
						if (openrdoor.opened) {
							openrdoor.opened = false;
							textcontroller.drawText ("冷蔵庫の扉を閉めた。");
						} else {
							openrdoor.opened = true;
							textcontroller.drawText ("冷蔵庫の扉を開けた。");
						}
					}
				} else if (objectName == "RDoor2") {
					openrdoor = rdoor2.GetComponent<OpenRDoor> ();
					if (openrdoor.opened) {
						openrdoor.opened = false;
						textcontroller.drawText ("冷蔵庫の扉を閉めた。");
					} else {
						openrdoor.opened = true;
						textcontroller.drawText ("冷蔵庫の扉を開けた。");
					}
				} else if (objectName2 == "Refrigerator") {
					textcontroller.drawText ("何の変哲もない冷蔵庫だ。");
				}
				if (objectName == "ak47_2") {
					GameObject obj = GameObject.Find ("ak47");
					Vector3 scale = obj.transform.localScale;
					scale.x = 1f;
					scale.y = 1f;
					scale.z = 1f;
					obj.transform.localScale = scale;

					GameObject obj2 = GameObject.Find ("ak47_2");
					Destroy (obj2);

					textcontroller.drawText ("AK-47（のモデルガン）を手に入れた！" + System.Environment.NewLine + "（右クリックで発砲できます。）");
				}
				if (objectName == "Curtain" || objectName == "Curtain_Closed" ) {
					GameObject obj1 = GameObject.Find ("Curtain");
					GameObject obj2 = GameObject.Find ("Curtain_Closed");
					Vector3 scale1 = obj1.transform.localScale;
					Vector3 scale2 = obj2.transform.localScale;
					if (curtainClosed == false) {
						textcontroller.drawText ("Curtainを閉めた。");
						scale1.x = 0f;
						scale1.z = 0f;
						scale2.x = 0.4f;
						scale2.z = 0.8f;
						curtainClosed = true;
						lights[6].SetActive (false);
					} else {
						textcontroller.drawText ("カーテンを開けた。");
						scale1.x = 0.4f;
						scale1.z = 0.8f;
						scale2.x = 0f;
						scale2.z = 0f;
						curtainClosed = false;
						lights [6].SetActive (true);
					}
					obj1.transform.localScale = scale1;
					obj2.transform.localScale = scale2;
				}
				if (objectName == "Conditioner1" || objectName == "Conditioner2") {
					textcontroller.drawText("何の変哲もないエアコンだ。");
				}
				if (objectName == "Table1" || objectName == "Table2" || objectName == "Table3" || objectName == "Table4") {
					textcontroller.drawText("何の変哲もない机だ。上には何も置かれていない。");
				}
				if (objectName == "Table5") {
					textcontroller.drawText ("何の変哲もない机だ。パソコンが置かれている。");
				}
				if (objectName == "Keyboard005") {
					textcontroller.drawText ("何の変哲もないキーボードだ。");
				}
				if (objectName == "Monitor005") {
					textcontroller.drawText ("パソコンのモニターだ。Windows XPがインストールされている様だ。");
				}
				if (objectName == "PC005") {
					textcontroller.drawText ("パソコンの本体だ。");
				}
				if (objectName == "Printer") {
					textcontroller.drawText ("何の変哲もないプリンタだ。");
				}
				if (objectName == "Chair1" || objectName == "Chair2" || objectName == "Chair2" || objectName == "Chair3" || objectName == "Chair4" || objectName == "Chair5" || objectName == "Chair6" || objectName == "Chair7" || objectName == "Chair8" || objectName == "Chair9") {
					textcontroller.drawText ("何の変哲もない椅子だ。");
				}
				if (objectName2 == "ProjectionMapping") {
					textcontroller.drawText ("プロジェクションマッピングの装置だ。");
				}
				if (objectName2 == "Shelf") {
					textcontroller.drawText ("何の変哲もない棚だ。");
				}
				if (objectName2 == "Shelf2") {
					textcontroller.drawText ("棚だ。電気ケトルの様なもの、オーブントースターの様なもの、電子レンジの様なものが置かれている。");
				}
				if (objectName2 == "WhiteBoard") {
					if (lights [0].activeSelf == false && lights [6].activeSelf == false) {
						textcontroller.drawText ("数字が書かれている。");
					} else {
						textcontroller.drawText ("何の変哲もないホワイトボードだ。");
					}
				}
				if (objectName == "WhiteBoard2") {
					textcontroller.drawText ("何の変哲もないホワイトボードだ。何か書かれているが、重要なことではなさそうだ。");
				}
				if (objectName2 == "DustBox") {
					textcontroller.drawText ("何の変哲もないゴミ箱だ。");
				}
				if (objectName == "Switches") {
					textcontroller.drawText ("スイッチ類だ。操作する必要はなさそうだ。");
				}
				if (objectName == "Plug") {
					textcontroller.drawText ("コンセントの差込口だ。");
				}
				if (objectName == "Door1") {
					textcontroller.drawText ("扉がある。外側から鍵が掛けられている様だ。");
				}
				if (objectName == "Door2") {
					textcontroller.drawText ("TK309と書かれている。");
				}
				if (objectName == "Switches") {
					textcontroller.drawText ("操作する必要は無さそうだ。");
				}
				if (objectName == "Switch") {
					if (lightIsOn == true) {
						textcontroller.drawText ("電気を消した。");
						for (int i = 0; i < 6; i++) {
							lights [i].SetActive (false);
						}
						lightIsOn = false;
					} else {
						textcontroller.drawText ("電気を点けた。");
						for (int i = 0; i < 6; i++) {
							lights [i].SetActive (true);
						}
						lightIsOn = true;
					}
				}
				if (objectName == "CardReader") {
					if (cardGot == false) {
						textcontroller.drawText ("カードリーダーだ。カードをかざすと扉が開くかもしれない。");
					} else {
						textcontroller.drawText ("扉が開いた！");
						opendoor = door.GetComponent<OpenDoor> ();
						opendoor.opened = true;
					}
				}
				if (objectName == "Card") {
					textcontroller.drawText ("学生証を手に入れた！");
					cardGot = true;
				}
			}
		}


		if (lights [0].activeSelf == false && lights [6].activeSelf == false) {
			GameObject obj1 = GameObject.Find ("Num1");
			GameObject obj2 = GameObject.Find ("Num2");
			Vector3 scale1 = obj1.transform.localScale;
			Vector3 scale2 = obj2.transform.localScale;
			scale1.x = 0.96f;
			scale1.z = 0.96f;
			scale2.x = 0.96f;
			scale2.z = 0.96f;
			obj1.transform.localScale = scale1;
			obj2.transform.localScale = scale2;
			numberSaw = true;
		}
	}
}
