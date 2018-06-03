using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public int maxNotas;
	public float speedNotas = 0.4f;
	public int numRestar;
	public int contCombo = 0;

	public bool moverse = true;

    public int numEnemigos;
    public int nivel;

    public bool spawn = false;
	public bool empezar = false;

	private static Manager instance = null;

	public Text notasRestantes;

	public GameObject[] enemies;
	public GameObject win;
	public Transform posWin;

	public Text nivelTxt;



	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("nivel") == null){
			PlayerPrefs.SetInt ("nivel", 1);
		}
		nivel = PlayerPrefs.GetInt ("nivel");
		maxNotas += PlayerPrefs.GetInt ("nivel") * 10;
        numEnemigos = maxNotas;
    }
	
	// Update is called once per frame
	void Update () {

		nivelTxt.text = (PlayerPrefs.GetInt("nivel")).ToString();
        notasRestantes.text = (maxNotas).ToString();
		enemies = GameObject.FindGameObjectsWithTag ("Enemie");
        
		if (enemies.Length == 0 && empezar)
        {
			StartCoroutine ("SiguienteNivel");
        }
  	}

	IEnumerator SiguienteNivel(){
		//Debug.Log("aSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
		GameObject newCombo = Instantiate (win, posWin.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(5.0f);
		PlayerPrefs.SetInt ("nivel", nivel += 1);
		SceneManager.LoadScene(1);
	}

}
