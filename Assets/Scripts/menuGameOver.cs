using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuGameOver : MonoBehaviour {

	public Button btnEmpezar, btnSalir;

	// Use this for initialization
	void Start () {
		btnEmpezar.GetComponent<Button> ();
		btnSalir.GetComponent<Button> ();

		btnEmpezar.onClick.AddListener (CambiarEscena);
		btnSalir.onClick.AddListener (Application.Quit);
		PlayerPrefs.SetInt ("nivel", 1);
	}

	// Update is called once per frame
	void Update () {

	}

	public void CambiarEscena(){
		SceneManager.LoadScene (1);
	}
}
