using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    bool moveUp = true;

    public float moveSpeed = 10;

    Vector2 origin;

	// Use this for initialization
	void Start ()
    {

        origin = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveUp)
        {

            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

            if (transform.position.y - origin.y > 4)
                moveUp = false;


        }

        else
        {

            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            if (transform.position.y - origin.y < 0)
                moveUp = true;
        }

	}
}
