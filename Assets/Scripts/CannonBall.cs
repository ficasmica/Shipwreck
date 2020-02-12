using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Explosion explosion;
    public Explosion bigExplosion;
    private Animation anim;
    public GameObject explosionHitBox;

    void Start(){
        anim = GetComponent<Animation>();
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
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "static" || col.gameObject.tag == "player" || col.gameObject.tag == "cannonBall"){
            Explosion explosionClone = Instantiate(explosion, transform.position, transform.rotation) as Explosion;
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "ammo"){
            Explosion explosionClone = Instantiate(explosion, transform.position, transform.rotation) as Explosion;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "bomb"){
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
