using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : steeringBehaviour {
    public GameObject centre;
    public float maxSpeed;
	// Use this for initialization
	void Start () {
        boid = GetComponent<Boid>();
    }

    public override Vector3 calculate()
    {
        Vector3 posRelToCentre = centre.transform.position - transform.position;
        float distance = posRelToCentre.magnitude;
        float angle = Vector3.Angle(centre.transform.position, transform.position);
        

        Quaternion desiredAngle = Quaternion.Euler(0, (angle + 5) % 360, 0);

        Vector3 targetPos = desiredAngle * centre.transform.position;
        targetPos.Normalize();
        Debug.Log(targetPos); 
        //float angle = Vector3.Angle



        transform.LookAt(centre.transform);
        Vector3 direction = transform.right;
        transform.LookAt(direction);
        direction.Normalize();
        direction *= maxSpeed;
        direction += transform.position;

        //Quaternion desiredAngle = Quaternion.Euler(0, (angle + 5) % 360, 0);
        //Vector3 targetPos = new Vector3(distance, 0, 0) + centre.transform.position;
        //targetPos = desiredAngle * targetPos;
        //Debug.Log(angle);

        return boid.seekTarget(targetPos * distance);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
