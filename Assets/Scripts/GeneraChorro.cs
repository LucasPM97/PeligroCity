using UnityEngine;
using System.Collections;

public class GeneraChorro : MonoBehaviour {
	public GameObject[] chorro;
	public GameObject lluvia;
	Material calle;
	public GameObject callecita;
	Quaternion lalo;
	bool subir;
	int rand;
	float rota;
	bool perdisteamigo = false;
	public float randomlluvia =0;

	public float TiempMin = 2f;
	public float TiempMax = 5f;
	// Use this for initialization
	void Start () {
		randomlluvia = Random.Range (1,2);
		if (randomlluvia > 1) {
			lluvia.SetActive (true);
		}
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
		Generation ();
	}
	void frenar(){
		perdisteamigo = true;;
	}
	void GO(){
		perdisteamigo = true;
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= -0.70f) {
			subir = false;
		} else if (transform.position.y <= -3.91f) {
			subir = true;
		} 
		if (subir == true) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.3f, transform.position.z+0.3f);
		}
		if (subir == false) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.3f, transform.position.z-0.3f);
		}
	}
	void Generation (){
		if (perdisteamigo == false) {
			calle = callecita.GetComponent<Renderer> ().material;
			rand = Random.Range (0, chorro.Length);
			rota = 0;
			if (rand == 0 || rand == 1) {
				rota = 180;
			}
			lalo = Quaternion.Euler (transform.rotation.x, transform.rotation.y + rota, transform.rotation.z);

			if (rand == 2) {

				if (calle.mainTextureOffset.x >= 0.2f && calle.mainTextureOffset.x <= 0.5f) {
					Instantiate (chorro [rand], transform.position, lalo);
				}
				if (calle.mainTextureOffset.x >= 0.7f) {
					Instantiate (chorro [rand], transform.position, lalo);
				}
			} else {
				Instantiate (chorro [rand], transform.position, lalo);
			}


			Invoke ("Generation", Random.Range (TiempMin, TiempMax));
		}
	}

}
