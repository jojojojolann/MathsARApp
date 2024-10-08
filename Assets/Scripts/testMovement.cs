using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    public float Yspeed = 20.0f;

    void Update()
    {
        transform.Translate(Vector3.up * Yspeed * Time.deltaTime);
    }
}
