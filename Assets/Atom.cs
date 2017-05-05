using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {

    public string Electrons_Per_Shell = "1";
    public string atom = "exampleName";
    public GameObject protonPrefab;
    public GameObject electonPrefab;

    private int[] shells;
    private GameObject proton;
    private GameObject[] electrons;
    private float ringDist = 3;

	// Use this for initialization
	void Start () {
        string[] shells = Electrons_Per_Shell.Split(',');
        this.shells = new int[shells.Length];


        for (int i = 0; i < shells.Length; i++)
        {
            this.shells[i] = int.Parse(shells[i]);
        }

        spawnAtom();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void spawnAtom()
    {
        proton = Instantiate(protonPrefab, transform.position, transform.rotation);
        proton.transform.parent = transform;

        for (int i = 0; i < this.shells.Length; i++)
        {
            float curRingDist = ringDist * (i + 1);
            float degreesOfSeperation = 360 / this.shells[i];

            for (int j = 0; j < this.shells[i]; j++)
            {

                Quaternion spawnOffset = Quaternion.Euler(0, degreesOfSeperation * (j + 1), 0);
                Vector3 spawnPos = new Vector3(curRingDist, 0, 0) + transform.position;

                spawnPos = spawnOffset * spawnPos;
                Debug.Log("i:" + i + " j:" + j + " curRingDist:" + curRingDist + " degreesOfSeperation:" + degreesOfSeperation + " spawnOffset:" + spawnOffset);
                GameObject electron = Instantiate(electonPrefab, spawnPos, transform.rotation);
                electron.transform.parent = proton.transform;
                electron.GetComponent<orbit>().centre = proton;
            }
        }
    }
}
