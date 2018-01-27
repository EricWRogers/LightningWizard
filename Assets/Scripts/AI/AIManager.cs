using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    GameObject playerGameObject;

    Unit[] units;

    void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

	// Use this for initialization
	void Start () {
		foreach(Unit unit in units)
	    {
            unit.prepareToEngage();
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
