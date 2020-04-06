using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    void Start()
    {
        // convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);
        Paddle paddlePlayer = Instantiate(paddle) as Paddle;
        Paddle paddleAI = Instantiate(paddle) as Paddle;
        paddlePlayer.Init(true); //right paddle
        paddleAI.Init(false); //left paddle
    }
    
    public void TryAgain()
    {
        ScoreData.AiScore = 0;
        ScoreData.PlayerScore = 0;
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        //TODO maybe reset score? Unsure how to proceed.... Or maybe reset score but keep highscore?
        ScoreData.PlayerScore = 0;
        ScoreData.AiScore = 0;
        SceneManager.LoadScene(0);
    }

}
