using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBall : MonoBehaviour {

	public int dmg = 30;
	public float speed = 500;
	Rigidbody rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = (transform.right * speed); //Instantly apply force towards the bullets forward direction on the bullet
		Destroy(gameObject, 1f);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy") && other.GetComponent<EnemyHealth>()!=null) {
			other.GetComponent<EnemyHealth>().TakeDamage(dmg);
		}
	}
}

