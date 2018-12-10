using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerFollow : MonoBehaviour {

    Transform trigger;

	// Use this for initialization
	void Start ()
    {

        trigger = GameObject.Find("hero").transform;
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = new Vector2(trigger.position.x, transform.position.y);
		
	}
}
