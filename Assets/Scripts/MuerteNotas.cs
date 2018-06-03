using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteNotas : MonoBehaviour {

	public GameObject juegoMusica;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		//print ("ha chocao");
		if (other.gameObject.tag == "Nota") {
			Destroy (other.gameObject);
		}
	}
}
