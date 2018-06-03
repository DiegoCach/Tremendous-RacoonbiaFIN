using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    private int life = 3;
    private bool shoot = true;
    private bool CD;
    private bool knock;
    private Image life1;
    private Image life2;
    private Image life3;
    public Sprite black;
    private float speed = 0.3f;
    public float force = 20.0f;

    public GameObject bala;
    public GameObject gun;
	public GameObject vara;

	GameObject manager;
	Manager managerCtrl;
	Animator anim;

    // Use this for initialization
    void Start () {
        life1 = GameObject.Find("life1").GetComponent<Image>();
        life2 = GameObject.Find("life2").GetComponent<Image>();
        life3 = GameObject.Find("life3").GetComponent<Image>();

		manager = GameObject.Find ("Manager");
		managerCtrl = manager.GetComponent<Manager> ();
		anim = vara.GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (managerCtrl.moverse) {
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate (Vector2.right * speed);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector2.left * speed);
			}
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate (Vector2.up * speed);
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate (Vector2.down * speed);
			}
			if (Input.GetMouseButtonDown(1) && CD == false)
			{
				StartCoroutine(Melee());
			}

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonDown(0) && shoot == true)
			{
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
				//RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos2D - (Vector2) transform.position);
				GameObject balaNueva = Instantiate(bala, gun.transform.position, Quaternion.identity);
				Rigidbody2D rgbProyectil = balaNueva.GetComponent<Rigidbody2D>();
				rgbProyectil.velocity = (mousePos2D - (Vector2) transform.position) * force;


			}


		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.tag == "Enemie" || collision.transform.tag == "trampa" )
        {
            switch (life)
            {
                case 3:
                    life3.sprite = black;
                    break;
                case 2:
                    life2.sprite = black;
                    break;
                case 1:
                    life1.sprite = black;
                    break;
            }
            life--;
            if (knock == false)
            {
                //StartCoroutine(Damage(collision));
            }
            if (life <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    IEnumerator Damage(Collision2D c)
    {
        knock = true;
        Vector3 dir = (Vector3)c.contacts[0].point - transform.position;
        dir = -dir.normalized;
        gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 200);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(dir * -200);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        knock = false;
        yield break;
    }

    IEnumerator Melee()
    {
        CD = true;
		anim.SetBool ("Atacar", true);
		transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.2f);
		transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        CD = false;
		anim.SetBool ("Atacar", false);
        yield break;
    }

	IEnumerator Gun()
	{
		CD = true;
		transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		CD = false;
		yield break;
	}
}