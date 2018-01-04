using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
     
    public AudioSource jumpSound;
    public AudioSource collectSound;
    public AudioSource dieSound; 
    private bool dead = false;
     
    public GameObject blackHole;
    private bool mouseDown;
    public float orbitSpeed = 100f;
    public float gravityForce = .006f;
    public float inverseGravityForce = .006f;

    void Start()
    {
        rb.gravityScale = 0;
        //gameObject.GetComponent<TrailRenderer>().material.color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            if (!dieSound.isPlaying)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            return;
        }
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        { 
            mouseDown = true;

        }
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        if (mouseDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, -1 * inverseGravityForce);
        } 
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, gravityForce);
        }
        // Rotate around the sun.  
        transform.RotateAround(blackHole.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }

    // This triggers everytime a rigid body collides with a collider
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Game OVER!");
        if (dead)
        {
            return;
        }
        if (col.tag == "Missile")
        { 
            Destroy(col.gameObject); 
        } 
        dieSound.Play();
        dead = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    } 
}
