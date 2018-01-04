using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

    public GameObject missile;
    public float maxPos = 2000.0f;
    public float minPos = 9.0f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("spawn", .5f, .5f);
    }

    void spawn()
    {
        float randomX;
        float randomY;

        // Algorithm to make missles spawn at random points.
        float randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        { 
            randomNum = Random.Range(0, 2);
            randomX = Random.Range(-20, 1);
            if (randomNum == 0)
            {
                randomY = -10;
            } 
            else
            {
                randomY = 10;
            }
        }
        else
        { 
            randomNum = Random.Range(0, 2); 
            randomY = Random.Range(-10, 11);
            if (randomNum == 0)
            {
                randomX = -20;
            }
            else
            {
                randomX = 1;
            }
        }


        Vector3 theNewPos = new Vector3(randomX, randomY, 0);
        GameObject go = Instantiate(missile);
        go.transform.position = theNewPos;
    } 
}
