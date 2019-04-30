using UnityEngine;
using System.Collections;

public class GeneraAuto : MonoBehaviour {
	public GameObject[] autitos;
	Quaternion lalo;
	bool perdisteamigo = false;
	public bool otro;
	public float timemin = 1f;
	public float timemax = 10f;
	int random;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
		Generaautitos ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void frenar(){
		perdisteamigo = true;;
	}
	void GO(){
		perdisteamigo = true;
	}
	void Generaautitos (){
		lalo = Quaternion.Euler (transform.rotation.x, 0, transform.rotation.z);
		random = Random.Range (0, autitos.Length);
		if (perdisteamigo == false) {
			if (otro == false && random != 0) {
				lalo = Quaternion.Euler (transform.rotation.x, 180, transform.rotation.z);
			} 
			Instantiate (autitos [random], transform.position, lalo);
			Invoke ("Generaautitos", Random.Range (timemin, timemax));
		}
	}
}
