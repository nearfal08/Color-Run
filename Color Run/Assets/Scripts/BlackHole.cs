using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public SpriteRenderer planetSprite;
    public Sprite[] planetSprites;
    public GameObject Debris;

    // Use this for initialization
    void Start () {
        planetSprite.sprite = planetSprites[Random.Range(0, planetSprites.Length)];
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // TO DO: Spawn debris
        if (col.tag == "Missile")
        {
            Vector3 theNewPos = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 0);
            GameObject go = Instantiate(Debris);
            go.transform.position = theNewPos;
        } 

        Destroy(col.gameObject);

        // TO DO: Add to game score 
    }
}
