using UnityEngine;
using System.Collections;

public class ChorroTsunami : MonoBehaviour {
	public GameObject[] chorro;
	public GameObject subte;
	public GameObject generador;
	public AudioSource tsunami;
	public Animator abricion;
	public Animator quad;
	Material calle;
	Quaternion lalo;
	public bool subir;
	int rand;
	float rota;
	bool perdisteamigo = false;

	public float TiempMin = 0.01f;
	public float TiempMax = 2f;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
		empezar.empiezo = false;
		Generation ();
		Update ();
	}
	void frenar(){
		perdisteamigo = true;;
	}
	void GO(){
		perdisteamigo = true;
	}
	// Update is called once per frame
	void Update () {
		if (perdisteamigo == false) {

			if (tsunami.time >= 28) {
				TiempMax = 1.5f;
			}
			if (tsunami.time >= 40) {
				TiempMax = 0.7f;
			}
			if (tsunami.time >= 51) {
				Destroy (generador.gameObject);
				subte.SetActive (true);
				quad.SetBool ("alocado", true);
			}
			if (tsunami.time >= 64) {
				abricion.SetBool ("abrir", true);
			}
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
			if (tsunami.time >= 76) {
				if (perdisteamigo == false) {
					TiempMax = 0.1f;
					ControladorPersonaje.perder = true;
				} else {
					ControladorPersonaje.perder = false;
				}
			}
		}

	}
	void Generation (){
		if (perdisteamigo == false) {
			rand = Random.Range (0, chorro.Length);
			rota = 0;
			if (rand == 0 || rand == 1) {
				rota = 180;
			}
			lalo = Quaternion.Euler (transform.rotation.x, transform.rotation.y + rota, transform.rotation.z);
			Instantiate (chorro [rand], transform.position, lalo);
			Invoke ("Generation", Random.Range (TiempMin, TiempMax));
		}
	}

}
