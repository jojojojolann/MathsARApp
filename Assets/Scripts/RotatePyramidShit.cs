using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePyramidShit : MonoBehaviour
{
    public float rotationSpeedY = 20.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeedY * Time.deltaTime);
    }
}