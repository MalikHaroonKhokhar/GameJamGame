using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float spreadVirusTimer = 4f;
    private float currentTimer = 0f;

    void Update()
    {
        if(currentTimer > spreadVirusTimer)
        {
            Instantiate(gameObject, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Instantiate(gameObject, transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
            currentTimer = 0f;
        }
        else
        {
            currentTimer += Time.deltaTime;
        }
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
       
    }
}
