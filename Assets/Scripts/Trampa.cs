﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed));
	}
}
