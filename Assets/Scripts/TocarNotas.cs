using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarNotas : MonoBehaviour {

	public KeyCode key;
	public ParticleSystem efecto;

	SpriteRenderer render;

	public GameObject nota;
	bool pulsar = false;

	GameObject manager;
	Manager managerCtrl;

	public GameObject combo;
	public Transform posCombo;

	Color originalColor;

	// Use this for initialization
	void Start () {
		render = this.GetComponent<SpriteRenderer> ();

		manager = GameObject.Find ("Manager");
		managerCtrl = manager.GetComponent<Manager> ();

		originalColor = render.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key)){
			render.color = Color.yellow;
			if(pulsar) {
				Destroy (nota);
				ParticleSystem newEfecto = Instantiate (efecto, this.transform.position, Quaternion.identity);
				Destroy (newEfecto.gameObject, 0.3f);
				managerCtrl.maxNotas--;
				managerCtrl.contCombo++;
			}
		}
		if (Input.GetKeyUp (key)) {
			render.color = originalColor;
		}

		if(managerCtrl.contCombo == 10){
			GameObject newCombo = Instantiate (combo, posCombo.transform.position, Quaternion.identity);
			Destroy (newCombo.gameObject, 1f);
			managerCtrl.contCombo = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		//print ("ha chocao");
		if (other.gameObject.tag == "Nota") {
			nota = other.gameObject;
			pulsar = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		//print ("ha chocao");
		if (other.gameObject.tag == "Nota") {
			pulsar = false;
			//contCombo = 0;
		}
	}
}
