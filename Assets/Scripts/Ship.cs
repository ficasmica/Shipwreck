using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleInputNamespace;

public class Ship : MonoBehaviour
{
    public CannonBall cannonBall;
    public Transform rightGun;
    public Transform leftGun;
    public SteeringWheel wheel;
    public float speed;
    private float wheelRot;
    public Sprite[] sprites;
    private SpriteRenderer sprtRend;
    private int n = 0;
    public DeadEnemy deadEnemy;

    void Start(){
        sprtRend = GetComponent<SpriteRenderer>();
        sprtRend.sprite = sprites[n];
    }

    void Update(){
        wheelRot = wheel.wheelAngle * 0.1f;
        
        if (Mathf.Abs(wheel.wheelAngle) >= 0f && Mathf.Abs(wheel.wheelAngle) < 180f){
            speed = 0.8f;
        }
        else if (Mathf.Abs(wheel.wheelAngle) >= 180f && Mathf.Abs(wheel.wheelAngle) < 360f){
            speed = 0.65f;
        }
        else if (Mathf.Abs(wheel.wheelAngle) >= 360f && Mathf.Abs(wheel.wheelAngle) < 540f){
            speed = 0.45f;
        }
    }

    void FixedUpdate(){
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Rotate(-Vector3.forward * wheelRot * Time.deltaTime, Space.World);
    }

    public void ShootRight(){
        CannonBall cannonBallClone = Instantiate(cannonBall, rightGun.position, rightGun.rotation);
    }

    public void ShootLeft(){
        CannonBall cannonBallClone = Instantiate(cannonBall, leftGun.position, leftGun.rotation);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "cannonBall"){
            if (n != 2){
                n += 1;
                sprtRend.sprite = sprites[n];
            }
            else{
                DeadEnemy deadEnemyClone = Instantiate(deadEnemy, transform.position, transform.rotation) as DeadEnemy;
                Destroy(gameObject);
            }
        }
    }
}
