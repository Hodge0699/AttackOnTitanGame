using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 18;

    private Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();     
    }

    void Update()
    {
        float hAixs = Input.GetAxis("Horizontal");
        float vAixs = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(hAixs, 0, vAixs) * speed * Time.deltaTime;


        rig.MovePosition(transform.position + movement);
    }
}