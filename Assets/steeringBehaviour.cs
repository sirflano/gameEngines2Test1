using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class steeringBehaviour : MonoBehaviour {

    public float weight = 1;
    public Boid boid;

    void start()
    {
        boid = GetComponent<Boid>();
    }

    public abstract Vector3 calculate();
}
