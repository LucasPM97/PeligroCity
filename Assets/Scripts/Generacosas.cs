using UnityEngine;
using System.Collections;

public class Generacosas : MonoBehaviour {
	 Material calle;
	public static bool modohardcoreXD = false;
	Quaternion lalo;
	public GameObject callecita;
	public GameObject[] cosas;
	int randomcito;
	public float timer = 2;
	public bool otro = false;
	bool perdisteamigo = false;
	int randomcito2;
	int limite = 50;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
		GenerarCosas ();
	}
	void GO(){
		perdisteamigo = true;
	}
	void frenar(){
		perdisteamigo = true;;
	}
	// Update is called once per frame
	void Update () {
		calle = callecita.GetComponent<Renderer> ().material;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			/*if (calle.mainTextureOffset.x <= 0.01f) 
		{
			Instantiate (cosas [Random.Range (0,cosas.Length)], transform.position, Quaternion.identity);
		}*/
			if (calle.mainTextureOffset.x >= 0.2f && calle.mainTextureOffset.x <= 0.5f) {
				GenerarCosas ();
			}
			if (calle.mainTextureOffset.x >= 0.7f) {
				GenerarCosas ();
			}
			timer = Random.Range (1,7);
		}
	}
	void GenerarCosas(){
		lalo = Quaternion.Euler (transform.rotation.x, 0, transform.rotation.z);
		if (perdisteamigo == false) {
			if(Puntaje.puntos >= limite){
				if (calle.mainTextureOffset.x >= 0.2f && calle.mainTextureOffset.x <= 0.5f) {
					transform.position = new Vector3 (transform.position.x, -1.2f, transform.position.z);
					limite += Random.Range (40,70);
					Instantiate (cosas [9], transform.position, lalo);
				}
				if (calle.mainTextureOffset.x >= 0.7f) {
					transform.position = new Vector3 (transform.position.x, -1.2f, transform.position.z);
					limite += Random.Range (40,70);
					Instantiate (cosas [9], transform.position, lalo);
				}
			}
			else{
				randomcito = Random.Range (0, cosas.Length-1);
				if (randomcito != randomcito2) {
					randomcito2 = randomcito;
					if (!otro) {
						transform.position = new Vector3 (transform.position.x, 0.46f, transform.position.z); //arriba
					} else { 
						transform.position = new Vector3 (transform.position.x, 8.46f, transform.position.z); //abajo
					}
					if (otro) {
						if (randomcito == 3 || randomcito == 7) {
							transform.position = new Vector3 (transform.position.x, 7.3f, transform.position.z);
						}
						if (randomcito == 1 || randomcito == 2 || randomcito == 0) {
							transform.position = new Vector3 (transform.position.x, 8.4f, transform.position.z);
						}
						if (randomcito == 5) {
							transform.position = new Vector3 (transform.position.x, 10f, transform.position.z);
						}
						if (randomcito == 4) {
							lalo = Quaternion.Euler (transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
						}

					}
					if (!otro) {
						if (randomcito == 1 || randomcito == 0 || randomcito == 2) {
							transform.position = new Vector3 (transform.position.x, 0.79f, transform.position.z);
						}
						if (randomcito == 4) {
							transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
						}
						if (randomcito == 3 || randomcito == 6) {
							transform.position = new Vector3 (transform.position.x, 0.04f, transform.position.z);
						}
						if (randomcito == 5) {
							transform.position = new Vector3 (transform.position.x, 1.1f, transform.position.z);
						}
						if (randomcito == 7) {
							transform.position = new Vector3 (transform.position.x, -0.6f, transform.position.z);
						}
					}
					Instantiate (cosas [randomcito], transform.position, lalo);
				}
			}
		}

	}
}
