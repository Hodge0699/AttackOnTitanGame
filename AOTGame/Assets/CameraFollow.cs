using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public bool userOffsetValues;
    public float rotateSpeed;
    public Transform pivot;

    void Start()
    {
      if (!userOffsetValues)
        {
            offset = target.position - transform.position;

        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;

    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);
        
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(vertical, 0, 0);

        //if(pivot.rotation.eulerAngles.x > 0f && pivot.rotation.eulerAngles.x <0f)
        //{
        //    pivot.rotation = Quaternion.Euler(0f, 0, 0);
        //}
        //if (pivot.rotation.eulerAngles.x > 0 && pivot.rotation.eulerAngles.x < 0f)
        //{
        //    pivot.rotation = Quaternion.Euler(0f, 0, 0);
        //}

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y -.5f, transform.position.z);
        }
        transform.LookAt(target);
    }
}
