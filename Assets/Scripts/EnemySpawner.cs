﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.AI;
public class EnemySpawner : NetworkBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemies;

    

    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 position = new Vector3(Random.Range(-6f, 6f), 1, Random.Range(-6f, 6f));

            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            GameObject enemy = Instantiate(enemyPrefab, position, rotation) as GameObject;

            NetworkServer.Spawn(enemy);

            

           
           
        }  
    }
	

}
