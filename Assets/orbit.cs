using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : steeringBehaviour {
    public GameObject centre;
	// Use this for initialization
	void Start () {
		
	}

    public override Vector3 calculate()
    {
        Vector3 posRelToCentre = centre.transform.position - transform.position;
        float distance = posRelToCentre.magnitude;


        return boid.seekTarget(centre.transform.position);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
