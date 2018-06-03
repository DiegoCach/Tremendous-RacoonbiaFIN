using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    private int Enemies;
    public GameObject[] kind;
    public Vector2[] vectorEnemieSpawn;
    Manager managerCtrl;

    // Use this for initialization
    void Start () {
        GameObject manager = GameObject.Find("Manager");
        managerCtrl = manager.GetComponent<Manager>();
    }
	
	// Update is called once per frame
	void Update () {
		Enemies = managerCtrl.maxNotas + PlayerPrefs.GetInt("nivel") * 10;
        if (managerCtrl.spawn == true)
        {
            for (int i = 0; i < Enemies; i++)
            {
                int randEn = Random.Range(0, 2);
                vectorEnemieSpawn[0] = new Vector2(Random.Range(12, 17), Random.Range(12, 17));
                vectorEnemieSpawn[1] = new Vector2(Random.Range(-17, -12), Random.Range(12, 17));
                Vector2 randVec = vectorEnemieSpawn[Random.Range(0, 2)];
                Instantiate(kind[randEn], randVec, Quaternion.identity);
            }
            managerCtrl.spawn = false;
        }
    }
}
