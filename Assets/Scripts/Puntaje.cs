using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour {
	int contpuntos;
	public static float puntos;
	float timer = 0.5f;
	float tiempito = 0.5f;
	public TextMesh Puntuacion_txt;
	bool perdisteamigo = false;
	public GameObject GameOver;
	public TextMesh PuntosGameOver;
	public TextMesh RecordGameOver;
	public TextMesh[] letras;
	public static Puntaje puntuacion;
	public GameObject nombrecitos;
	bool paso = false;
	//public Font fuente;
	bool aRecord = false;
	string lalo = "A";
	int yo = 65;
	public Animator flechas;
	int letr = 0;
	int pos;
	string nombre;


	void Awake(){
		if (puntuacion == null) {
			DontDestroyOnLoad (this.gameObject);
			DontDestroyOnLoad (GameOver.gameObject);
			puntuacion = this;
		}
	}
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"termino");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");

	}
	void GO(){
		perdisteamigo = true;
		GameOver.SetActive (true);

	}

	// Update is called once per frame
	void Update () {
		if (perdisteamigo == false) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				puntos++;
				Puntuacion_txt.text = ((int)puntos).ToString ();
				timer = tiempito;
			}
		} else {
			Puntuacion_txt.text ="";
			if (contpuntos < (int)puntos) {
				contpuntos++;
				PuntosGameOver.text = contpuntos.ToString ();
			}
			if ((int)puntos > DatosPrinc.record[9] && paso == false) {
				nombrecitos.SetActive (true);
				//NotificationCenter.DefaultCenter ().PostNotification (this,"Record",(int)puntos);
				if((int)puntos > DatosPrinc.record[0]){
					RecordGameOver.text = puntos.ToString();
				}
				aRecord = true;
				paso = true;
			}
			if ((int)puntos < DatosPrinc.record[9]) {
				RecordGameOver.text = DatosPrinc.record[0].ToString ();
			}
			/*if (Input.inputString != "") {
				int asciicode = System.Convert.ToInt32 (Input.inputString [0]); 
				char num = (char)asciicode;
				lalo = num.ToString ();
				Debug.Log (lalo);
			}*/
			char num = (char)yo;
			lalo = num.ToString ();
			letras[letr].text = lalo;
			if (Input.GetKeyDown(KeyCode.DownArrow)){
				yo += 1;
				if (yo > 90) {
					yo = 49;
				}
				if (yo > 57 && yo < 65) {
					yo = 65;
				}
				nombre = ""+letras[0].text+""+letras[1].text+""+letras[2].text;
				Debug.Log (nombre);
				Debug.Log (yo);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				yo -= 1;
				if (yo < 49) {
					yo = 90;
				}
				if (yo > 57 && yo < 65) {
					yo = 57;
				}
				nombre = ""+letras[0].text+""+letras[1].text+""+letras[2].text;
				Debug.Log (nombre);
				// 32 a 126
				// de 90 a 49
				// de 57 a 65
				Debug.Log (yo);
			}
			if (Input.GetKeyDown (KeyCode.LeftControl)) {
				if (aRecord == true) {
					letr += 1;
					if(letr == 1){
						flechas .SetBool ("mover1",true);
						yo = 65;
					}
					if(letr == 2){
						flechas.SetBool ("mover2",true);
						yo = 65;
					}
					if (letr > 2) {
						NotificationCenter.DefaultCenter ().PostNotification (this,"Recordnum",(int)puntos);
						NotificationCenter.DefaultCenter ().PostNotification (this,"Recordnom",nombre);
						puntos = 0;
						Destroy (GameOver.gameObject);
						Destroy (this.gameObject);
						SceneManager.LoadScene ("Records");
					}
				} else {
					puntos = 0;
					Destroy (GameOver.gameObject);
					Destroy (this.gameObject);
					SceneManager.LoadScene ("Menu");
				}
			}
		}
	}
}
