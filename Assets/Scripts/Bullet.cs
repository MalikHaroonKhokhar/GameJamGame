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
        rb=GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        rb.velocity= transform.up * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            scoreManager.IncreaseScore(scoreValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);   
        }
        if (collision.gameObject.CompareTag("Organ"))
        {

            Destroy(gameObject);
        }
    }
}
