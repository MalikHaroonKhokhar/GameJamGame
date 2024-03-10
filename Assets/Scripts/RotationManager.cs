using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed = 5f;


    public GameObject bulletPrefab;
    public Transform shootpoint;
    public float bulletDelay = 2.0f; // Time delay before spawning the bullet
    private float bulletTimer = 0f;


    private void FixedUpdate()
    {
        Animate();
        Vector3 inputDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f).normalized;

        if (inputDirection != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, targetRotation - 90f), rotationSpeed * Time.fixedDeltaTime);
        
            if(bulletTimer > bulletDelay)
            {
                if(Powers.hasSpreadBullet)
                {
                    Quaternion angle = Quaternion.AngleAxis(-15f, transform.forward); // Adjust the spread angle here
                    Instantiate(bulletPrefab, shootpoint.position, transform.rotation * Quaternion.Euler(0, 0, 90f));
                    Instantiate(bulletPrefab, shootpoint.position, transform.rotation * angle * Quaternion.Euler(0, 0, 90f));
                    Instantiate(bulletPrefab, shootpoint.position, transform.rotation * Quaternion.Inverse(angle) * Quaternion.Euler(0, 0, 90f));

                    bulletTimer = 0f;
                }
                else if (Powers.areRedBloodCellsAttacking)
                {
                     
                }
                else
                {
                    Instantiate(bulletPrefab, shootpoint.position, transform.rotation * Quaternion.Euler(0,0,90f));
                    bulletTimer = 0f;
                }
                
            }   
            else
            {
                bulletTimer += Time.deltaTime;
            }
        }
    }


    private void Animate()
    {
        float scaleFactor = Mathf.Abs(Mathf.Sin(Time.time)) * 0.125f + 0.15f;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

}
