using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int scoreValue = 1;

    private ScoreManager scoreManager;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(scoreValue);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Organ") )
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Rbc")){
            Destroy(gameObject);

        }
    }
}
