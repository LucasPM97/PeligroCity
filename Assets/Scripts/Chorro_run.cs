using UnityEngine;
using System.Collections;

public class Chorro_run : MonoBehaviour {

	public float velocidad= 0;
	public Transform chorro;
	bool perdisteamigo = false;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"GO");
		NotificationCenter.DefaultCenter ().AddObserver (this,"frenar");
	}
	void GO(){
		perdisteamigo = true;
	}
	void frenar(){
		perdisteamigo = true;;
	}
	// Update is called once per frame
	void Update () {
		if (perdisteamigo == false) {
			chorro.position = new Vector3 (chorro.position.x - velocidad, chorro.position.y, chorro.position.z);
		} else {
			Destroy (this.gameObject);
		}
	}
}
