using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed;

    void Start(){
    }

    void FixedUpdate(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
