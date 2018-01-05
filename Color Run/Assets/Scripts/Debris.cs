using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{

    public GameObject blackHole;
    public float gravityForce = .05f;
    public float inverseGravityForce = .05f;
    public Rigidbody2D rb;
    public float jumpForce = 10f;
    private bool isFalling = false;
    public float orbitSpeed = 100f;
    // Use this for initialization
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(blackHole.transform.position, transform.position);
        if (distance > 5)
        {
            isFalling = true; 
        }

        if (isFalling)
        {
            transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, gravityForce);
            //Debug.Log("Falling");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, -1 * inverseGravityForce); 
            //Debug.Log("Rising");
        }
        transform.RotateAround(blackHole.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    } 

    void OnDestroy()
    {
        Debug.Log("Debris Dead");
    }

    void OnTriggerEnter2D(Collider2D col)
    { 

        Destroy(gameObject);

        // TO DO: Add to game score 
    }
}
