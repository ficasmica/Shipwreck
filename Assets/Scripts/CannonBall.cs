using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start(){

    }

    void Update(){
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f){
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag != "gun" && col.gameObject.tag != "detector"){
            Destroy(gameObject);
        }
    }
}
