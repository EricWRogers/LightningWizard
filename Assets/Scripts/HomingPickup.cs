using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingPickup : MonoBehaviour {
	public GameObject player = null;
	public Transform target = null;

	public float speed = 5f;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;
	//private GameLoop gameloop = GameObject.Find("GM").GetComponent <GameLoop> ();
	// Use this for initialization
	void Start () {
		findPlayer();
		rb = GetComponent<Rigidbody2D>();
	}
	IEnumerator MyCoroutine()
    {
            yield return new WaitForSeconds(.5f);
            findPlayer();
    }
	private void findPlayer(){
        player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
    }
	void FixedUpdate () {
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;


	}
	
	void OnTriggerEnter2D (Collider2D collision)
	{
		// Put a particle effect here
		if(collision.gameObject.tag == "Player")
		{
			//gameloop.Magic++;
			collision.GetComponent<PlayerHealthandSave>().manaUp();
			Destroy(gameObject);
		}
			
	}
}