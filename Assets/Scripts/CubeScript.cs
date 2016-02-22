using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	int number;
	public TextMesh mesh;
	public bool alive = true;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		//mesh = transform.GetChild (0).GetComponent<TextMesh> ();
		alive = true;
	
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (alive) {
			gameObject.layer = LayerMask.NameToLayer("Default");
			mesh.text =  number.ToString ();
		} else {
			gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			mesh.text = "";
		}
		
		
	
	}

	public void SetNumber(int num){
		this.number = num;
		mesh.text = num.ToString ();
		mesh.transform.parent = null;
		transform.localScale = new Vector3 (num.ToString ("D").Length, 1, 1);
		mesh.transform.parent = this.transform;
		
	}
	public int GetNumber(){
		return number;

	}
	public void DestroyCube(){
		alive = false;


	}
}
