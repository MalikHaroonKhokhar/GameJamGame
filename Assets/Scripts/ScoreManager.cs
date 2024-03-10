using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;


    void Start()
    {
        UpdateScoreText();

    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }


   public int GetCurrentScore()
    {
        return score;
    }

    public void DecreaseScore(int amount )
    {
        score -= amount;
    }
}
