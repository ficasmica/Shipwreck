using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public CannonBall cannonBall;
    public Transform rightGun;
    public Transform leftGun;

    public void ShootRight(){
        CannonBall cannonBallClone = Instantiate(cannonBall, rightGun.position, rightGun.rotation);
    }

    public void ShootLeft(){
        CannonBall cannonBallClone = Instantiate(cannonBall, leftGun.position, leftGun.rotation);
    }
}
