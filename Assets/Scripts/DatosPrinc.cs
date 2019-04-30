using UnityEngine;
using System.Collections;using UnityEngine.SceneManagement;


public class DatosPrinc : MonoBehaviour {
	public static int[] record = new int[]{0,0,0,0,0,0,0,0,0,0};
	public static string[] nombres = new string[]{"ABC","ABC","ABC","ABC","ABC","ABC","ABC","ABC","ABC","ABC"};
	public AudioSource cancioncita;
	public static int vidas = 3;
	int num;
	string nom;
	float tiempito = 50;
	float Max = 50;
	float Rtiempito = 10;
	public static DatosPrinc yo;
	void Awake(){
		if (yo == null) {
			DontDestroyOnLoad (this.gameObject);
			yo = this;
		} else if(yo != this){
			Destroy (this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"Record");
		NotificationCenter.DefaultCenter ().AddObserver (this,"Recordnom");
		NotificationCenter.DefaultCenter ().AddObserver (this,"Recordnum");
	}
	void Recordnum(Notification notif){
		num = (int)notif.data;
	}
	void Recordnom(Notification notif){
		nom = (string)notif.data;
		if (num != 0 || num != null) {
			Record ();
		}
	}
	void Record(){
		int nuevo = num;
		for (int x = 9 ; x >= 0 ; x--) {
			if (nuevo > record [x]) {
				if (x == 9) {
					record [9] = nuevo;
					nombres [9] = nom;
				} else {
					record [x + 1] = record [x]; 
					nombres [x + 1] = nombres[x]; 
					record [x] = nuevo;
					nombres [x] = nom;
				}
			}
		}
		for (int x = 0 ; x < record.LongLength; x++) {
			Debug.Log ("Posición "+x+" : "+record[x]+" con Nombre : "+nombres[x]);
		}
	}
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "Subte"){
			cancioncita.Stop ();
		}
		if (SceneManager.GetActiveScene ().name == "Play") {
			if (cancioncita.isPlaying == false) {
				cancioncita.Play ();
			}
		}
		if (SceneManager.GetActiveScene ().name == "Records") {
			Rtiempito -= Time.deltaTime;
			if (Rtiempito <= 0) {
				Rtiempito = Max;
				SceneManager.LoadScene ("Menu");
			}
			if (Input.GetKeyDown("o")){
				Rtiempito = Max;
				SceneManager.LoadScene ("Menu");
			}
		}
		if (SceneManager.GetActiveScene ().name == "Menu") {
			tiempito -= Time.deltaTime;
			if (tiempito <= 0) {
				tiempito = Max;
				SceneManager.LoadScene ("Records");
			}
			if (Input.GetKeyDown("o")){
				tiempito = Max;
				SceneManager.LoadScene ("Play");
			}
		}
	}
}
