using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script does 2 things:
 * -spawning one (only one) platform to the right of the current one when the player gets closer than minDistance
 * -destroying the current platform if the player moves to the right of the platform of more than minDistance
 * 
 * To make this work you should disable the SpawnManager gameobject (the one that does the normal spawning of the platforms) 
 * and add this script to the platform (Ground) prefab.
 */
public class PlatformManager : MonoBehaviour {

    Transform playerTransform;
    public GameObject platform; //remember to add the prefab in the inpector
    public int minDistance = 30;
    public float horizontalMin = 7.5f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6;

    bool hasSpawned = false;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //if player is close enough instantiate new platform
        if (!hasSpawned && (transform.position.x - playerTransform.position.x) < minDistance)
        {
            Spawn();
            hasSpawned = true;
        }

        //if too far behind destroy
        if ( -(transform.position.x - playerTransform.position.x) > minDistance)
        {
            Destroy(gameObject);
        }
    }

    void Spawn()
    {
        Vector2 randomPosition = (Vector2) transform.position + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
        Instantiate(platform, randomPosition, Quaternion.identity);
        //transform.position = randomPosition;
    }
}
