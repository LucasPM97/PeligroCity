using UnityEngine;
using System.Collections;

public class empezar : MonoBehaviour {
	public static bool empiezo = false;
	public Animator animacion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (empiezo == true) {
			animacion.SetBool("empezar",true);
		}
	}
}
