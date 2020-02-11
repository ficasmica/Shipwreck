using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    private int enemyCount;
    private Vector3 spawnPoint;
    private float timeBetweenSpawns;
    private float spawnTimer;

    void Start(){
        timeBetweenSpawns = Random.Range(20f, 30f);
        spawnTimer = timeBetweenSpawns;
    }

    void Update(){
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f){
            spawnTimer = timeBetweenSpawns;
            spawnPoint = new Vector3(Random.Range(-7f, 7f), Random.Range(8f, -9f), 0f);
            Enemy enemyClone = Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}
