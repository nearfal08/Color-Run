using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    private Vector3 lastPosition;
    private float distanceTraveled = 0;

    void Start()
    {
        lastPosition = player.position;
    }

    // Update is called once per frame
    void Update () {
        if (player)
        {
            distanceTraveled += Vector3.Distance(player.position, lastPosition);
            scoreText.text = distanceTraveled.ToString("0");
            lastPosition = player.position;
        } 
    }
}
