using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float Sprinting = 15;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;
    public float jumpForce;

    void Start()
    {
        controller = GetComponent<CharacterController>();     
    }

    void Update()
    {
        float yStore = moveDirection.y;
        //moveDirection = new Vector3 (Input.GetAxis("Horizontal") * speed, 0f,  Input.GetAxis("Vertical") * speed);
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")); 
        moveDirection = moveDirection.normalized * speed;
        moveDirection.y = yStore;
        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //if(Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    Sprinting = 15;
        //}
    }
}