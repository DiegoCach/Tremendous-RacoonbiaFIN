using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearNota : MonoBehaviour {

	GameObject nota;
	public GameObject nota1;
	public GameObject nota2;
	public GameObject nota3;
	public GameObject nota4;

	public Transform pos1;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;

	Transform[] posiciones;

	public float speed;
	public float time = 0;
	int ultNota = 0;
	int maxNotas;
	int cont;
	int num;

    bool empezar = false;
	bool terminar = false;

	GameObject manager;
	Manager managerCtrl;

	public GameObject[] clones;

    GameObject player;
    GameObject canvas2;
	public GameObject oscuro;

    // Use this for initialization
    void Start () {
		posiciones = new Transform[4];
		posiciones [0] = pos1;
		posiciones [1] = pos2;
		posiciones [2] = pos3;
		posiciones [3] = pos4;
		manager = GameObject.Find ("Manager");
		managerCtrl = manager.GetComponent<Manager> ();
		speed = managerCtrl.speedNotas;
		maxNotas = managerCtrl.maxNotas + PlayerPrefs.GetInt("nivel") * 10;
        player = GameObject.Find("Player");
        canvas2 = GameObject.Find("Canvas2");
		GameObject.Find("Player").GetComponent<SpriteRenderer>().sortingOrder = -1;
		canvas2.GetComponent<Canvas> ().sortingOrder = 20;
		managerCtrl.moverse = false;
    }
	
	// Update is called once per frame
	void Update () {
		clones = GameObject.FindGameObjectsWithTag ("Nota");

		time += Time.deltaTime;
        StartCoroutine("Espera");
		if (time > speed && maxNotas > 0 && empezar) {
			float random = Random.value;
			if (random < 0.9) {
				num = 1;
			} else if (random >= 0.9f && maxNotas > 1) {
				num = 2;
			}
			//print (num);
			for (int i = 0; i < num; i++) {
				int n = Random.Range (0, 4);
				if (n != ultNota) {
					StartCoroutine (NuevaNota (posiciones [n]));
					ultNota = n;
					time = 0;
				}
			}
		}
		if (maxNotas == 0) {
			if (clones.Length == 0 && terminar == false) {
				StartCoroutine ("End");
				terminar = true;
			}
		}
	}

	IEnumerator NuevaNota (Transform pos){
		switch (pos.name) {
		case "pos1":
			nota = nota1;
				break;
			case "pos2":
			nota = nota2;
				break;
			case "pos3":
			nota = nota3;
				break;
			case "pos4":
			nota = nota4;
				break;
		}
		GameObject notaNueva = Instantiate (nota, pos.position, Quaternion.identity);
		notaNueva.gameObject.layer = 10;
		maxNotas--;
		yield break;
	}

    IEnumerator End()
    {
		print ("TERMINADO");
        yield return new WaitForSeconds(3.0f);
        if (maxNotas == 0)
        {
			
            GameObject.Find("JuegoMusical").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("CREANOTAS").SetActive(false);
			GameObject.Find("Player").GetComponent<SpriteRenderer>().sortingOrder = 20;
			oscuro.SetActive (false);
			canvas2.GetComponent<Canvas> ().sortingOrder = 20;
            GameObject.Find("bailongo").SetActive(false);
            managerCtrl.spawn = true;
			managerCtrl.numEnemigos = maxNotas;
			managerCtrl.moverse = true;
        }
        yield break;
    }

    IEnumerator Espera () {
        yield return new WaitForSeconds(3.0f);
        empezar = true;
    }

}
