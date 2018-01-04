using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public GameObject blackHole; 
    public float gravityForce = .05f; 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, gravityForce);
    }

    void OnDestroy()
    {
        Debug.Log("Missile Dead"); 
    }
}
