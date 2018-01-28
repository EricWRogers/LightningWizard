using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMove : MonoBehaviour
{
    public float teleportWaitTime = 0.5f;
    public float teleportRange = 10f;

    CharacterController characterController;
    PlayerController playerController;

    bool isTeleporting = false;
    float lastTeleportTime = 0;
    Vector3 nextTeleportTarget;

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

                Vector3 endPos = new Vector3(dir.x, dir.y, dir.z);
	            endPos = endPos*teleportDist;

                startTeleport(endPos);
	        }
	    }

	    if (isTeleporting && Time.time - lastTeleportTime > teleportWaitTime)
	    {
	        teleportTo(nextTeleportTarget);
	    }
	}


    void startTeleport(Vector3 endPos)
    {
        playerController.canMove = false;
        isTeleporting = true;
        lastTeleportTime = Time.time;
        nextTeleportTarget = endPos;

        oldScale = transform.localScale;
        transform.localScale = Vector3.zero;

        //Moving the position too below the ground
    }

    void teleportTo(Vector3 targetPos)
    {
        playerController.canMove = true;
        isTeleporting = false;

        transform.position = targetPos;
        transform.localScale = oldScale;
    }
}
