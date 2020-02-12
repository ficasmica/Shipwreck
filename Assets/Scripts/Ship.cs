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
    public bool isWrecked;
    private float shootTimer;
    public float timeBetweenShots;
    private bool canShoot = true;
    public Button fireButtonLeft;
    public Button fireButtonRight;
    public int ammo;
    public Text ammoLabel;
    public GameObject ammoBarrel;

    void Start(){
        sprtRend = GetComponent<SpriteRenderer>();
        sprtRend.sprite = sprites[n];
        shootTimer = timeBetweenShots;
        isWrecked = false;
    }

    void Update(){
        if (!isWrecked){
            wheelRot = wheel.wheelAngle * 0.1f;
        
            if (Mathf.Abs(wheel.wheelAngle) >= 0f && Mathf.Abs(wheel.wheelAngle) < 180f){
                speed = 0.8f;
            }
            else if (Mathf.Abs(wheel.wheelAngle) >= 180f && Mathf.Abs(wheel.wheelAngle) < 360f){
                speed = 0.7f;
            }
            else if (Mathf.Abs(wheel.wheelAngle) >= 360f && Mathf.Abs(wheel.wheelAngle) < 540f){
                speed = 0.55f;
            }
        }

        if (!canShoot && !isWrecked){
            shootTimer -= Time.deltaTime;
            fireButtonLeft.GetComponent<Image>().fillAmount += 0.33f * Time.deltaTime;
            fireButtonRight.GetComponent<Image>().fillAmount += 0.33f * Time.deltaTime;

            if (shootTimer <= 0f){
                canShoot = true;
                shootTimer = timeBetweenShots;
            }
        }
    }

    void FixedUpdate(){
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Rotate(-Vector3.forward * wheelRot * Time.deltaTime, Space.World);

        if (isWrecked){
            canShoot = false;
            speed = Mathf.Lerp(speed, 0.0f, 0.025f);
            if (speed <= 0.01f){
                speed = 0f;
            }
            wheelRot = 0.0f;
        }

        if (ammo > 6){
            ammo = 6;
        }
        ammoLabel.text = "Ammo: " + ammo;
    }

    public void ShootRight(){
        if (!canShoot){
            return;
        }
        else{
            if (ammo == 0){
                return;
            }
            else{
                canShoot = false;
                CannonBall cannonBallClone = Instantiate(cannonBall, rightGun.position, rightGun.rotation);
                ammo -= 1;
                fireButtonLeft.GetComponent<Image>().fillAmount = 0f;
                fireButtonRight.GetComponent<Image>().fillAmount = 0f;
            }
        }
    }

    public void ShootLeft(){
        if (!canShoot){
            return;
        }
        else{
            if (ammo == 0){
                return;
            }
            else{
                canShoot = false;
                CannonBall cannonBallClone = Instantiate(cannonBall, leftGun.position, leftGun.rotation);
                ammo -= 1;
                fireButtonLeft.GetComponent<Image>().fillAmount = 0f;
                fireButtonRight.GetComponent<Image>().fillAmount = 0f;
            }
        }
    }

    public void DropBomb(){
        if (ammo < 2){
            return;
        }
        else{
            GameObject ammoBarrelClone = Instantiate(ammoBarrel, transform.position - transform.TransformDirection(Vector3.up), Quaternion.identity) as GameObject;
            ammo -= 2;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "cannonBall"){
            if (n != 2){
                n += 1;
                sprtRend.sprite = sprites[n];
            }
            else if (n == 2){
                sprtRend.sprite = sprites[3];
                isWrecked = true;
                canShoot = false;
            }
        }

        else if (col.gameObject.tag == "bomb"){
            if (n < 1){
                n += 2;
                sprtRend.sprite = sprites[n];
            }
            else{
                sprtRend.sprite = sprites[3];
                isWrecked = true;
                canShoot = false;
            }
        }

        else if (col.gameObject.tag == "static"){
            isWrecked = true;
            canShoot = false;
        }

        else if (col.gameObject.tag == "ammo"){
            Destroy(col.gameObject);
            ammo += Random.Range(1, 4);
        }
    }
}
