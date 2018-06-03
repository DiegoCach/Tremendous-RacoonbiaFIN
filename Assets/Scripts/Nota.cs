using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour {

	public float speed = 0.4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.down * speed);
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Muerte") {
			Destroy (this.gameObject);
		}
	}
}
