using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorPersonaje : MonoBehaviour {
	public Animator tipitoanim;
	public Collider2D tipitocoll;
	bool auch = false;
	float dañadito = 2;
	float tiempo = 2;
	public static bool perder = false;
	public static ControladorPersonaje control;

	void Awake(){
		if (control == null) {
			DontDestroyOnLoad (this.gameObject);
			control = this;
		} else if(control == this){
			Destroy (this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		DatosPrinc.vidas = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(auch == true){
			dañadito -= Time.deltaTime;
			if (dañadito <= 0) {
				dañadito = tiempo;
				tipitoanim.SetBool ("danado",false);
				tipitocoll.enabled = true;
				auch = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "Chorro(Clone)" || coll.gameObject.name == "Chorro_negro(Clone)") {
			if (perder == false) {
				DatosPrinc.vidas--;
				if (DatosPrinc.vidas >= 0) {
					NotificationCenter.DefaultCenter ().PostNotification (this, "Explotar", DatosPrinc.vidas);
				}
				if (DatosPrinc.vidas < 0) {
					Destroy (this.gameObject);
					DatosPrinc.vidas = 3;
					NotificationCenter.DefaultCenter ().PostNotification (this, "GO");

				}
				tipitocoll.enabled = false;
				tipitoanim.SetBool ("danado", true);
				auch = true;
			} else {
				NotificationCenter.DefaultCenter ().PostNotification (this, "GO");
				Destroy (this.gameObject);
				perder = false;
			}
		}
	}
}
