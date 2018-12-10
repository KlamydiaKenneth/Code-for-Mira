using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    AudioSource coinSound;


    // Use this for initialization
    void Start()
    {

        GameObject player;
        player = GameObject.Find("hero");
        coinSound = player.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (coinSound != null)
                coinSound.Play();
            Destroy(gameObject);
        }


    }
}
