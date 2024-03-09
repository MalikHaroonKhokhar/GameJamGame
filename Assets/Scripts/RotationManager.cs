using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f).normalized;

        if (inputDirection != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, targetRotation - 90f), rotationSpeed * Time.fixedDeltaTime);
        }
    }

}
