using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        // Get the input direction from the joystick
        Vector3 inputDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f).normalized;

        // If there's some input (joystick not at rest)
        if (inputDirection != Vector3.zero)
        {
            // Calculate the target rotation angle based on input direction
            float targetRotation = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, targetRotation - 90f), rotationSpeed * Time.fixedDeltaTime);
        }
    }

}
