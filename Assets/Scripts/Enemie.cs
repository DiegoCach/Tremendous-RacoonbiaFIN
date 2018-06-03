using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour {

    private GameObject Player;
    private float speed = 8f;

    Manager managerCtrl;

    void Start()
    {
        Player = GameObject.Find("Player");
        GameObject manager = GameObject.Find("Manager");
        managerCtrl = manager.GetComponent<Manager>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        Vector3 vectorToTarget = Player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "melee")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "melee")
        {
            managerCtrl.numEnemigos--;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
			managerCtrl.empezar = true;
        }
    }
}
