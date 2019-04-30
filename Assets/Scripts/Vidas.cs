using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {
	public GameObject[] Corazoncito;
	public Animator[] Movimiento;
	bool corazon1si = false;
	bool corazon2si = false;
	bool corazon3si = false;
	public static Vidas viditas;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		if (viditas == null) {
			DontDestroyOnLoad (this.gameObject);
			viditas = this;
		} else if(viditas == this){
			Destroy (this.gameObject); 
		}
	}
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"Explotar");
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		Corazon ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GO(){
		Destroy (this.gameObject);
	}
	void Explotar(Notification notification){
		Movimiento [(int)notification.data].SetBool ("Explotar",true);
	}
	void Corazon(){
		if (corazon1si == false) {
			Movimiento [0].enabled = true;
			corazon1si = true;
			corazon2si = true;
		}
		else if (corazon2si == true) {
			Movimiento [1].enabled = true;
			corazon2si = false;
			corazon3si = true;
		}
		else if (corazon3si == true) {
			Movimiento [2].enabled = true;
			corazon3si = false;

		}
		Invoke ("Corazon", 0.1f);
	}
}
