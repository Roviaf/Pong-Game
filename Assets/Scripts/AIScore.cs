using UnityEngine.UI;
using UnityEngine;

public class AIScore : MonoBehaviour
{
    bool aiWon = false;
    Text scoreText;
    Ball ball;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = ScoreData.AiScore.ToString();
    }

    void Update()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        if (aiWon == false)
        {
            if (ball.aiWins == true)
            {
                ScoreData.AiScore += 1;
                scoreText.text = ScoreData.AiScore.ToString();
                aiWon = true;
            }
            if (ball.aiWinsCampaign == true)
            {
                ScoreData.AiScore = 0;
                ScoreData.PlayerScore = 0;
                ScoreData.AICampaignScore += 1;
                aiWon = true;

            }
            if (ball.aiWinsEndless == true)
            {
                ScoreData.AIEndlessScore += 1;
                aiWon = true;
            }
            if (ball.aiWinsLives == true)
            {
                ScoreData.AILivesScore += 1;
                aiWon = true;
            }
        }
    }
}