﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour
{
    public bool projectileMotion = false;
    public float upwardForceFactor = 100;
    public float speed = 5;

    Rigidbody rigidbody;

    Vector3 targetPos;



	// Use this for initialization
	void Start ()
	{
	    rigidbody = GetComponent<Rigidbody>();

        transform.LookAt(targetPos);
        rigidbody.velocity = transform.forward.normalized * speed;
        if (projectileMotion)
        {
            rigidbody.useGravity = true;
            rigidbody.AddRelativeForce(Vector3.up * upwardForceFactor);
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(targetPos);
    }

    public void setTarget(Vector3 pos)
    {
        targetPos = pos;
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
