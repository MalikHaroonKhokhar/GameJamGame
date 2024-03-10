using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public int scoreValue = 1; 

    private ScoreManager scoreManager;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        rb.velocity= transform.right * speed;
    }

    private void Update()
    {
        if (transform.position.x < -10 || transform.position.y < -10 || transform.position.y > 10 || transform.position.x > 10) Destroy(gameObject);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            scoreManager.IncreaseScore(scoreValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //if (collision.gameObject.CompareTag("Organ"))
        //{

        //    Destroy(gameObject);
        //}
    }
}
