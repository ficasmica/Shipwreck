using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorRight : MonoBehaviour
{
    public Enemy enemy;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "player"){
            enemy.isChasing = false;
            enemy.rightDetected = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "player"){
            enemy.rightDetected = false;
        }
    }
}
