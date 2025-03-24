using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public int oppScore = 0;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        playerScoreText.text = score.ToString();
    }

    public void OpponentAddScore(int points)
    {
        oppScore += points;
        opponentScoreText.text = oppScore.ToString();
    }
}
