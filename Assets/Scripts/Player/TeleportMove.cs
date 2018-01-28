using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMove : MonoBehaviour
{
    public float teleportRange = 10f;
    public float teleportSpeed = 10f;

    public ParticleSystem transmissionParticleSystem;

    CharacterController characterController;
    PlayerController playerController;

    bool isTeleporting = false;

    Vector3 teleportSource;
    Vector3 teleportTarget;

    Vector3 oldScale;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    // Use this for initialization
    void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Mouse0))
	    {
	        if (playerController.canMove)
	        {
	            Vector3 dir = transform.forward.normalized;
	            RaycastHit raycastHit;
	            bool didHit = Physics.Raycast(transform.position, dir, out raycastHit, teleportRange);

	            float teleportDist = teleportRange; 
                if (didHit)
                {
                    teleportDist = raycastHit.distance;
                }

                Vector3 endPos = transform.position + (dir * teleportDist);

                startTeleport(endPos);
	        }
	    }

	    if (isTeleporting)
	    {
	        float totalDist = Vector3.Distance(teleportSource, teleportTarget);
	        float currentDist = Vector3.Distance(teleportSource, transform.position);

	        if (currentDist >= totalDist)
	        {
	            stopTeleport();
	        }
	        else
	        {
	            characterController.Move((teleportTarget - transform.position).normalized * teleportSpeed);
	        }
	    }
	}


    void startTeleport(Vector3 endPos)
    {
        playerController.canMove = false;
        isTeleporting = true;

        teleportSource = transform.position;
        teleportTarget = endPos;

        oldScale = transform.localScale;
        transform.localScale = Vector3.zero;

        transmissionParticleSystem.Play();
    }

    void stopTeleport()
    {
        playerController.canMove = true;
        isTeleporting = false;

        transform.localScale = oldScale;

        transmissionParticleSystem.Stop();
    }
}
