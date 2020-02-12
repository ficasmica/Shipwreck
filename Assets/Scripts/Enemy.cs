using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Rigidbody2D rb;
    public float turnSpeed;
    public bool isChasing = true;
    public bool rightDetected = false;
    public bool leftDetected = false;
    public bool fireRight = false;
    public bool fireLeft = false;
    public Transform rightGun;
    public Transform leftGun;
    public CannonBall cannonBall;
    private float shootTimer;
    public float timeBetweenShots;
    private bool canShoot = true;
    public DeadEnemy deadEnemy;
    public GameObject ammo;
    private bool isWrecked = false;
    public Explosion explosion;
    public GameObject spawner;
    private EnemySpawner spawnerScript;
    private SpriteRenderer sprtRend;
    public Sprite sprt;
    private float deathTime = 5f;
    public Explosion bigExplosion;

    void Start(){
        sprtRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spawner = GameObject.FindGameObjectWithTag("suicide");
        spawnerScript = spawner.GetComponent<EnemySpawner>();
        player = GameObject.FindGameObjectWithTag("player");
        shootTimer = timeBetweenShots;
    }

    void Update(){
        if (!canShoot && !isWrecked){
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f){
                canShoot = true;
                shootTimer = timeBetweenShots;
            }
        }

        if (fireLeft){
            if (canShoot){
                CannonBall cannonBallClone = Instantiate(cannonBall, leftGun.position, leftGun.rotation) as CannonBall;
                //fireLeft = false;
                canShoot = false;
            }
        }
        else if (fireRight){
            if (canShoot){
                CannonBall cannonBallClone = Instantiate(cannonBall, rightGun.position, rightGun.rotation) as CannonBall;
                //fireLeft = false;
                canShoot = false;
            }
        }
    }

    void FixedUpdate(){
        Debug.Log(canShoot);
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        
        if (isChasing && !isWrecked){
            Vector3 toTarget = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, toTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        
        if (!isChasing && !isWrecked){
            if (rightDetected){
                transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            }
            else if (leftDetected){
                transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
            }
        }

        if (rightDetected == false && leftDetected == false){
            isChasing = true;
        }

        if (isWrecked){
            canShoot = false;
            speed = Mathf.Lerp(speed, 0.0f, 0.025f);
            if (speed <= 0.01f){
                speed = 0f;
            }
            deathTime -= Time.deltaTime;
            if (deathTime <= 0f){
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "cannonBall"){
            sprtRend.sprite = sprt;
            GameObject ammoClone = Instantiate(ammo, transform.position + transform.TransformDirection(-Vector3.up) * 0.75f, Quaternion.identity);
            isWrecked = true;
            spawnerScript.enemyCount -= 1;
            spawnerScript.score += 1;
        }

        else if (col.gameObject.tag == "static"){
            isWrecked = true;
            isChasing = false;
            spawnerScript.enemyCount -= 1;
        }

        else if (col.gameObject.tag == "bomb"){
            spawnerScript.enemyCount -= 1;
            sprtRend.sprite = sprt;
            GameObject ammoClone = Instantiate(ammo, transform.position + transform.TransformDirection(-Vector3.up) * 0.75f, Quaternion.identity);
            Destroy(col.gameObject);
            isWrecked = true;
            spawnerScript.score += 1;
        }
    }
}
