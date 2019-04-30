using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

	public bool sube = false;
	public Transform tipito;	
	bool subir;
	bool bajar;
	public float velociti = 0.05f;
	bool perdisteamigo = false;
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
	}
	void frenar(){
		perdisteamigo = true;;
	}
	// Update is called once per frame
	void Update () {
				if (subir) {
					if (tipito.position.y <= -0.65f) {
					tipito.position = new Vector3 (tipito.position.x, tipito.position.y+velociti, tipito.position.z + 0.1f);
					}
				}
				if (bajar) {
					if (tipito.position.y >= -3.91f) {
					tipito.position = new Vector3 (tipito.position.x, tipito.position.y- velociti, tipito.position.z - 0.1f);
					}
				}
			if (Input.GetMouseButtonUp (0)) {
				subir = false;
				bajar = false;

			}
		}

	void OnMouseDown(){
		if (perdisteamigo == false) {
			if (sube) {
				subir = true;
				bajar = false;
			}
			if (!sube) {
				subir = false;
				bajar = true;
			}
		}
	}
	void GO(){
		perdisteamigo = true;
	}
}
