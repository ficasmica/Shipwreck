using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGun : MonoBehaviour
{
    public Enemy enemy;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "player"){
            enemy.fireLeft = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "player"){
            enemy.fireLeft = false;
        }
    }
}
