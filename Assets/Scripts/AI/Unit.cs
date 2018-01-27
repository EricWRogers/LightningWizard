using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Soldier[] soldiers;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void marchTowardsPlayer(GameObject playerObject)
    {
        foreach (Soldier soldier in soldiers)
        {
            soldier.moveTowards(gameObject.transform.position);
        }
    }
}
