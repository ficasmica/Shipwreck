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
        timeBetweenSpawns = Random.Range(5f, 8f);
        spawnTimer = timeBetweenSpawns;
    }

    void Update(){
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f){
            //spawnTimer = timeBetweenSpawns;
            spawnPoint = new Vector3(Random.Range(-7f, 7f), Random.Range(8f, -9f), 0f);
            Vector3 checkSpawnPoint = Camera.main.WorldToViewportPoint(spawnPoint);
            if (checkSpawnPoint.x < 0f || checkSpawnPoint.x > 1f || checkSpawnPoint.y < 0.3f || checkSpawnPoint.y > 1f){
                Enemy enemyClone = Instantiate(enemy, spawnPoint, Quaternion.identity);
                spawnTimer = timeBetweenSpawns;
            }
            else{
                spawnPoint = new Vector3(Random.Range(-7f, 7f), Random.Range(8f, -9f), 0f);
            }
        }
    }
}
