using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour {

    public int health = 1;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}
    
    void Hurt()
    {
        health--;
        if(health <= 0)
            SceneManager.LoadScene("Scene1");
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == ("Enemy"))
        {
            Hurt();
        }
        


        /*
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //Destroy(other.gameObject);

            

            Application.LoadLevel(Application.loadedLevel);
        }
        */

    }
}
