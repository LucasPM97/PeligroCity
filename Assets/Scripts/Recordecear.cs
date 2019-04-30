using UnityEngine;
using System.Collections;

public class Recordecear : MonoBehaviour {
	public int id;
	public bool palabra;
	public TextMesh puntaje;
	// Use this for initialization
	void Start () {
		if (palabra == true) {
			if (DatosPrinc.nombres [id] == "" || DatosPrinc.nombres [id] == "ABC") {
				puntaje.text = "ABC"; 
			} else {
				puntaje.text = DatosPrinc.nombres [id]; 
			}
		} else {
			puntaje.text = DatosPrinc.record [id].ToString (); 
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
