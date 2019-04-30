using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public bool IniciarEnMovimiento = false;
	public float velocidad = 0f;
	bool perdisteamigo = false;
	private float tiempoInicio = 0f;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
			PersonajeEmpiezaACorrer();
	}
	void GO(){
		//perdisteamigo = true;
	}
	void frenar(){
		perdisteamigo = true;;
	}
	void PersonajeEmpiezaACorrer(){

		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(perdisteamigo == false){
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
		//Debug.Log (GetComponent<Renderer>().material.mainTextureOffset);
		}
	}
}
