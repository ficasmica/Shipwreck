using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{       
    private float time = 5f;

    void Update(){
        time -= Time.deltaTime;
        if (time <= 0f){
            Destroy(gameObject);
        }
    }
}
