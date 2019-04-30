using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
	public bool deplayero = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (deplayero == false) {
			Destroy (other.gameObject);
		} else {
			if (other.gameObject.name == "principal") {
				Destroy (other.gameObject);
				NotificationCenter.DefaultCenter ().PostNotification (this,"GO");


			}
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (deplayero == false) {
			Destroy (other.gameObject);
		}
		else {
			if (other.gameObject.name == "principal") {
				Destroy (other.gameObject);

			}
		}
	}
}
