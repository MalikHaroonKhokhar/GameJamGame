using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float spreadVirusTimer = 2f;
    private float offsetOfEnemyWithEachOther = 1f;
    private bool canSpreadVirus = true;
    private bool canKeepDamage = false;
    private HeathBar healthBar;
    private Rigidbody2D rb;

    private float currentTimer = 0f;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        healthBar = FindObjectOfType<HeathBar>();
    }   
    void Update()
    {

        if (transform.position.x < -10) Destroy(gameObject);
        if(currentTimer > spreadVirusTimer)
        {
            if(canSpreadVirus)
            {
                Instantiate(gameObject, transform.position + new Vector3(0f, 1f, 0f) * offsetOfEnemyWithEachOther, Quaternion.identity);
                Instantiate(gameObject, transform.position + new Vector3(0f, -1f, 0f) * offsetOfEnemyWithEachOther, Quaternion.identity);
                currentTimer = 0f;
                offsetOfEnemyWithEachOther += 1;
            }
           
        }
        else
        {
            currentTimer += Time.deltaTime;
        }
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
       
        if(canKeepDamage)
        {
            healthBar.ReduceHealth(0.001f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Organ"))
        {
            healthBar.ReduceHealth(1f);
            moveSpeed = 0f;
            rb.velocity = Vector2.zero;
            canSpreadVirus = false;
            canKeepDamage = true;
        }
    
    }

       

}
