using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    public float maxVelocity;
    public Vector3 velocity;
    public Vector3 force;
    public Vector3 acceleration;

    private List<steeringBehaviour> behaviours = new List<steeringBehaviour>();

	// Use this for initialization
	void Start () {
        steeringBehaviour[] behaviours = GetComponents<steeringBehaviour>();

        foreach(steeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);
        }
    }
	
	// Update is called once per frame
	void Update () {
        force = calculate();
	}

    public Vector3 seekTarget(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        toTarget.Normalize();
        toTarget *= maxVelocity;
        return toTarget - velocity;
    }

    private Vector3 calculate()
    {
        Vector3 tempForce = Vector3.zero;

        foreach(steeringBehaviour b in behaviours)
        {
            tempForce += b.calculate();
        }

        return tempForce;
    }
}
