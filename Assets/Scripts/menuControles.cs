using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuControles : MonoBehaviour {

	public Button btnBack;

	// Use this for initialization
	void Start () {
		btnBack.GetComponent<Button> ();
		btnBack.onClick.AddListener (CambiarEscena);
	}

	// Update is called once per frame
	void Update () {

	}

	public void CambiarEscena(){
		SceneManager.LoadScene (0);
	}
}
