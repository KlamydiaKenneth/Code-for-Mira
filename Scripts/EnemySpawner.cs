using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform[] enemyCtrl;
    public GameObject enemy;
    

	// Use this for initialization
	void Start ()
    {

        Spawn();
        
	}
	


    void Spawn()
    {

        for (int i = 0; i < enemyCtrl.Length; i++)
        {
            int enemyFlip = Random.Range(0, 4);
            if (enemyFlip == 0)
                Instantiate(enemy, enemyCtrl[i].position, Quaternion.identity);
        }
    }


    
}
