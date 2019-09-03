﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMovement : MonoBehaviour {

	public float MovementSpeed; 
    public GameObject Camera;


    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.current.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;


        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);

        }

       // Player Movement
       if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime); 
        }

    }

        
        
}
