using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	public Vector2 limitMax;
	public Vector2 limitMin;
	Transform target;
	public float smoothTime = 2;

	public float shakeCont;
	public float shakeAmount;

	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void LateUpdate () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		Vector3 destination = new Vector3 (target.position.x, target.position.y, -22f);

		this.transform.position = Vector3.Lerp(this.transform.position, destination, smoothTime * Time.deltaTime);

		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, limitMin.x, limitMax.x), Mathf.Clamp(this.transform.position.y, limitMin.y, limitMax.y), -22f);
	}

	void Update () {

		if (shakeCont >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
			this.transform.position = new Vector3 (this.transform.position.x + ShakePos.x, this.transform.position.y + ShakePos.y, -22f);

			shakeCont -= Time.deltaTime;
		}
	}

	public void ShakeCamera (float shakeForce, float time){
		shakeAmount = shakeForce;
		shakeCont = time;
	}
}