using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class PlayerScore : MonoBehaviour
{
    bool playerWon = false;
    Text scoreText;
    Ball ball;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = ScoreData.PlayerScore.ToString();
    }

    void Update()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        if (playerWon == false)
        {
            if (ball.playerWins == true)
            {
                ScoreData.PlayerScore += 1;
                scoreText.text = ScoreData.PlayerScore.ToString();
                playerWon = true;
            }
            if (ball.playerWinsCampaign == true)
            {
                ScoreData.PlayerCampaignScore +=1;
                playerWon = true;
            }
            if (ball.playerWinsEndless == true)
            {
                ScoreData.PlayerEndlessScore += 1;
                playerWon = true;
            }
            if (ball.playerWinsLives == true)
            {
                ScoreData.PlayerLivesScore += 1;
                playerWon = true;
            }
        }
    }
}