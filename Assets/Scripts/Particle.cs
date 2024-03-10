using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float moveSpeed = 2.5f;
    private float rotationSpeed = 50f;
    // Start is called before the first frame update
    private Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }


    public void setIniitalDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            // Reflect particles' direction based on the background's normal
            Vector3 reflectedVector = Vector3.Reflect(direction, collision.gameObject.transform.up).normalized;
            direction = reflectedVector;
        }
    }
}
