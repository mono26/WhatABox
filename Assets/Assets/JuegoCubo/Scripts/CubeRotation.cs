using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float turnSpeed;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if(horizontal > 0 || horizontal < 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * horizontal * Time.deltaTime);
        }
        if (vertical > 0 || vertical < 0)
        {
            transform.Rotate(Vector3.right, turnSpeed * vertical * Time.deltaTime);
        }
    }
}
