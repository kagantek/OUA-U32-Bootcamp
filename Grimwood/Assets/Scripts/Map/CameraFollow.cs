using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Camera cam;

    void LateUpdate()
    {
        Vector3 newPosition = target.position + offset;
        cam.transform.position = newPosition;
    }
}
