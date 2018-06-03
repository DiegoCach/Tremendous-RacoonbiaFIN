using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour {

	public Button btnEmpezar, btnSalir, btnControles;

	// Use this for initialization
	void Start () {
		btnEmpezar.GetComponent<Button> ();
		btnSalir.GetComponent<Button> ();
		btnControles.GetComponent<Button> ();

		btnEmpezar.onClick.AddListener (CambiarEscena);
		btnSalir.onClick.AddListener (Application.Quit);
		btnControles.onClick.AddListener (Controles);
		PlayerPrefs.SetInt ("nivel", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarEscena(){
		SceneManager.LoadScene (1);
	}
	public void Controles(){
		SceneManager.LoadScene (3);
	}
}
