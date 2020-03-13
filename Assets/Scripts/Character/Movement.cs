﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed=3f;

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position -= Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= Vector3.up * speed * Time.deltaTime;

    }
}
