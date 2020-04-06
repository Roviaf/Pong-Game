using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]float speed = 5f;
    [SerializeField]float height = 1f;
    string input;
    public bool isRight;
    GameObject ball;
    Ball ballScript;
    private void Start() 
    {
        height = transform.localScale.y;
        ball = GameObject.FindWithTag("Ball");
        ballScript = ball.GetComponent<Ball>();
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
        if(isRightPaddle)
        {
            pos = new Vector2 (GameManager.topRight.x, 0);
            pos -= (Vector2.right + Vector2.right) * transform.localScale.x;
            input = "AIPaddle";

        }
        else
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += (Vector2.right + Vector2.right) * transform.localScale.x;
            if (KeyBiddings.UPDOWN == 1)
            {
                input = "PaddleLeft";
            }
            if (KeyBiddings.WSkey == 1)
            {
                input = "PaddleLeftWS";
            }
            
        }
        transform.position = pos;
        transform.name = input;
    }

    void Update()
    {
        if (input == "AIPaddle") return;
        if (ballScript.playerWins == true || ballScript.aiWins == true || ballScript.aiWinsCampaign == true) return;
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + height / 1.5 && move < 0)
        {
            move = 0;
        }

        if (transform.position.y > GameManager.topRight.y - height / 1.5 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
        Vector2 AIpos = GameObject.Find("AIPaddle").transform.position;
        AiMovementSpeed(AIpos, AIDifficulty.AISpeed, AIDifficulty.BallDistance);

    }

    private void AiMovementSpeed(Vector2 AIpos, float aiSpeed, float ballDistance)
    {
        
        if (ballScript.playerWins == true || ballScript.aiWins == true || ballScript.aiWinsCampaign == true) 
        {
            return;
        }
        
        if (Vector2.Distance(AIpos, ball.transform.position) < ballDistance)
        {
            float difference = ball.transform.position.y - AIpos.y;
            if (difference >= -0.5 && difference <= 0.5) return;
            if (ball.transform.position.y >= AIpos.y)
            {
                if (AIpos.y > 4) return;
                GameObject.Find("AIPaddle").transform.Translate(aiSpeed * Vector2.up * Time.deltaTime);
            }
            else if (ball.transform.position.y <= AIpos.y)
            {
                if (AIpos.y < -4) return;
                GameObject.Find("AIPaddle").transform.Translate(aiSpeed * Vector2.down * Time.deltaTime);
            }
        }
        else
        {
            if (AIpos.y > 0.3)
            {
                GameObject.Find("AIPaddle").transform.Translate((aiSpeed - aiSpeed / 2) * Vector2.down * Time.deltaTime);
            }
            if (AIpos.y >= 0) return;
            if (AIpos.y < 0.3)
            {
                GameObject.Find("AIPaddle").transform.Translate((aiSpeed - aiSpeed / 2) * Vector2.up * Time.deltaTime);
            }

        }
    }
}
