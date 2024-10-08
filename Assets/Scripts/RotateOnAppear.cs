using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnAppear : MonoBehaviour
{
    public float rotationSpeedY = 20.0f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);
    }
}