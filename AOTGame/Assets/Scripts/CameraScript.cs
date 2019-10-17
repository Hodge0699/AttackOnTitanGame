﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    void Start()
    {
         
    }
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


}
