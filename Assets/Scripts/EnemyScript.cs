using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float spreadVirusTimer = 4f;
    private float offsetOfEnemyWithEachOther = 1f;
        private Rigidbody2D rb;

    private float currentTimer = 0f;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }   
    void Update()
    {
        if(currentTimer > spreadVirusTimer)
        {
            Instantiate(gameObject, transform.position + new Vector3(0f, 1f, 0f) * offsetOfEnemyWithEachOther, Quaternion.identity);
            Instantiate(gameObject, transform.position + new Vector3(0f, -1f, 0f) * offsetOfEnemyWithEachOther, Quaternion.identity);
            currentTimer = 0f;
            offsetOfEnemyWithEachOther += 1;
        }
        else
        {
            currentTimer += Time.deltaTime;
        }
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
       
    }
 
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Organ"))
        {
            moveSpeed = 0f;
            rb.velocity = Vector2.zero;
        }
    }

}
