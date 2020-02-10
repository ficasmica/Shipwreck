using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ship;
    public Vector3 offset;
    public float smoothSpeed;

    void LateUpdate(){
        transform.position = Vector3.Lerp(transform.position, ship.position + offset, smoothSpeed * Time.deltaTime);
    }
}
