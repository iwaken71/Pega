using UnityEngine;
using System.Collections;

public class CreatScript : MonoBehaviour {


	public GameObject numberCube;
	ArrayList list;
	public int minNum = 1;
	public int maxNum = 255;
	public int numCount = 10;
	int nownumber  = 0;

	// Use this for initialization
	void Start () {
		list = new ArrayList ();
		Generate (numCount);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo, 1000)) {
				if (hitInfo.collider.tag == "Number") {
					if (hitInfo.collider.GetComponent<CubeScript> ().alive) {
						int touchnum = hitInfo.collider.GetComponent<CubeScript> ().GetNumber ();
						if (touchnum == (int)list [nownumber]) {
							nownumber++;
							hitInfo.collider.GetComponent<CubeScript> ().DestroyCube ();
							if (nownumber >= numCount) {
								Application.LoadLevel ("Next");
							}


						} else {
							nownumber = 0;
							for(int i = 0; i < numCount; i++){
								GameObject.FindGameObjectsWithTag ("Number")[i].GetComponent<CubeScript>().alive = true;
							}
						}

					}
				}

			}

		}
	
	}

	void Generate(int num){
		

		for (int i = 0; i < num; i++) {
			
			Vector2 vec = Camera.main.ViewportToWorldPoint (new Vector2(Random.Range (0.0f, 0.5f), Random.Range (0.0f, 0.5f)));
			Vector3 pos = new Vector3 (Random.Range (-2, 2),0,Random.Range(-5,0));
			GameObject obj = Instantiate (numberCube, pos, Quaternion.identity) as GameObject;

			int random = (int)Random.Range (minNum, maxNum + 1);
			while (true) {
				int count = list.Count;
				if (count == 0) {
					break;
				}
				if (!list.Contains (random) || (maxNum - minNum + 1) < numCount ) {
					break;
				}
				random = (int)Random.Range (minNum, maxNum + 1);
			}
			obj.GetComponent<CubeScript> ().SetNumber (random);
			list.Add (random);
			list.Sort ();


		}
		//Debug.Log (list);
		PrintArray();
		

	}

	void PrintArray(){
		int num = list.Count;
		string aa = "";
		for (int i = 0; i < num; i++) {
			aa += ((int)list [i]).ToString () + "\r\n";
			
		}
		Debug.Log (aa);
	}
}
