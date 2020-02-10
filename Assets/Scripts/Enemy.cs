using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
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

    void Start(){
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("player");
        shootTimer = timeBetweenShots;
    }

    void Update(){
        if (!canShoot){
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
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        
        if (isChasing){
            Vector3 toTarget = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, toTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        
        if (!isChasing){
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
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "cannonBall"){
            Debug.Log("hit");
            DeadEnemy deadEnemyClone = Instantiate(deadEnemy, transform.position, transform.rotation) as DeadEnemy;
            Destroy(gameObject);
        }
    }
}
