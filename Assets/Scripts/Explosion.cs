using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float delete = 0.14f;

    void Update(){
        delete -= Time.deltaTime;
        if (delete <= 0f){
            Destroy(gameObject);
        }

    }
}
