using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public int enemyCount;
    private Vector3 spawnPoint;
    private float spawnTimer;
    public int score;
    public Text scoreLabel;

    void Start(){
        spawnTimer = 0f;
        score = 0;
    }

    void Update(){
        if (enemyCount < 5){
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f){
                spawnPoint = new Vector3(Random.Range(-7f, 7f), Random.Range(8f, -9f), 0f);
                Vector3 checkSpawnPoint = Camera.main.WorldToViewportPoint(spawnPoint);
                if (checkSpawnPoint.x < 0f || checkSpawnPoint.x > 1f || checkSpawnPoint.y < 0.3f || checkSpawnPoint.y > 1f){
                    Enemy enemyClone = Instantiate(enemy, spawnPoint, Quaternion.identity);
                    spawnTimer = Random.Range(4f, 8f);
                    enemyCount += 1;
                }
                else{
                    spawnPoint = new Vector3(Random.Range(-7f, 7f), Random.Range(8f, -9f), 0f);
                }
            }
        }
        else{
            return;
        }
        
        scoreLabel.text = "Score: " + score;
    }
}
