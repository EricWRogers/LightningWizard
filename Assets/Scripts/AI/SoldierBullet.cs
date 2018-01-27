using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour
{

    Rigidbody rigidbody;

    Vector3 bulletVelocity;

	// Use this for initialization
	void Start ()
	{
	    rigidbody = GetComponent<Rigidbody>();
	    rigidbody.velocity = bulletVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setVelocity(Vector3 vel)
    {
        bulletVelocity = vel;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Soldier>() != null)
        {
            return;
        }

        Destroy(gameObject);
    }
}
