using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	public Transform tipito;
	public Animator animacion;
	bool subir = false;
	bool bajar = false;
	float velociti = 0.05f;
	float sumax =0.01f;
	bool perdisteamigo = false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
	}
	// Update is called once per frame
	void Update () {
		
		if (perdisteamigo == false) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				subir = true;
			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				subir = false;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				bajar = true;

			}
			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				bajar = false;
			}
			if (subir) {
				if (tipito.position.y <= -0.70f) {
					tipito.position = new Vector3 (tipito.position.x, tipito.position.y + velociti, tipito.position.z + 0.1f);
				}
			}
			if (bajar) {
				if (tipito.position.y >= -3.91f) {
					tipito.position = new Vector3 (tipito.position.x, tipito.position.y - velociti, tipito.position.z - 0.1f);
				}
			}
			if (tipito.position.x < -4.56f) {
				tipito.position = new Vector3 (tipito.position.x + sumax, tipito.position.y, tipito.position.z);
			}
		}

	}
		
}
