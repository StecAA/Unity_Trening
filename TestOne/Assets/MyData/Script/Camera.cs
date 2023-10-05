using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float _speedRotate = 50;
    void Update()
    {
        if (gameObject.transform.rotation.x < -0.1)
        {
         if (Input.GetAxis("Mouse Y")<0) transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * _speedRotate * Time.fixedDeltaTime);
            return;
        }

        if (gameObject.transform.rotation.x > 0.33)
        {
            if (Input.GetAxis("Mouse Y") > 0) transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * _speedRotate * Time.fixedDeltaTime);
            return;
        }
        transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * _speedRotate * Time.fixedDeltaTime);
    }
}
