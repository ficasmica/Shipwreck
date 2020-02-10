using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGun : MonoBehaviour
{
    public Enemy enemy;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "player"){
            enemy.fireRight = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "player"){
            enemy.fireRight = false;
        }
    }
}
