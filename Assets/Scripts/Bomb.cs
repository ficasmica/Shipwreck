using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{   
    public GameObject hitBox;
    public Explosion bigExplosion;

    void OnTriggerEnter2D(Collider2D col){
        GameObject hitBoxClone = Instantiate(hitBox, transform.position, transform.rotation);
        Explosion bigExplosionClone = Instantiate(bigExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
