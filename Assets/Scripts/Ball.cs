using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    float radius;
    float countingTimer = 0f;

    public bool playerWins = false;
    public bool aiWins = false;
    

    public bool playerWinsCampaign = false;
    public bool playerWinsEndless = false;
    public bool playerWinsLives = false;

    public bool aiWinsCampaign = false;
    public bool aiWinsEndless = false;
    public bool aiWinsLives = false;


    bool weirdSoundBug = false;
    bool pauseOn = false;
    bool isSaved = false;
    GameObject canvasGameOver;
    GameObject canvasGameWon;
    GameObject canvasPause;
    AIScore aIScore;
    Vector2 direction;
    public AudioClip otherClip;

    void Start()
    {
        direction = Vector2.one.normalized; // direction is (1,1) normalized
        radius = transform.localScale.x / 2;
        canvasGameOver = GameObject.FindWithTag("GameOver");
        canvasGameWon = GameObject.FindWithTag("GameWon");
        canvasPause = GameObject.FindWithTag("PauseMenu");

        isSaved = false;

        playerWinsCampaign = false;
        playerWinsEndless = false;
        playerWinsLives = false;

        aiWinsCampaign = false;
        aiWinsEndless = false;
        aiWinsLives = false;

        playerWins = false;
        aiWins = false;

        canvasGameWon.SetActive(false);
        canvasGameOver.SetActive(false);
        canvasPause.SetActive(false);
        StartCoroutine(DelayInitialMovement(2f));
    }

    void Update()
    {
        countingTimer = Time.timeSinceLevelLoad;
        BallMovement(AIDifficulty.BallSpeed);
        GameModes();
        Pause();
        VictorySound();
    }

    // Saving

    public void SaveScore ()
    {
        SaveSystem.SaveHighscore();
    }


    void VictorySound()
    {
        if (weirdSoundBug == false)
        {
            if (playerWins == true || aiWins == true || aiWinsCampaign == true)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(otherClip);
                weirdSoundBug = true;
            }
        }
    }


    IEnumerator DelayInitialMovement(float delay)
    {
        Vector2 directionBall = new Vector2(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(1, -1));
        if (directionBall.x == 0)
        {
            directionBall.x = 1;
        }
        yield return new WaitForSeconds(delay);
        GetComponent<Rigidbody2D>().velocity = directionBall * speed;
    }


    private void BallMovement(float ballSpeed)
    {
        speed = ballSpeed;
        if (countingTimer > 6 && countingTimer < 10) speed += 1;
        if (countingTimer > 10 && countingTimer < 20) speed += 2;
        if (countingTimer > 20 && countingTimer < 25) speed += 3;
        if (countingTimer > 25 && countingTimer < 30) speed += 4;
        if (countingTimer > 30 && countingTimer < 40) speed += 5;
        if (countingTimer > 40) speed += 15;
    }

    private void Pause()
    {
        if (aiWins == true || playerWins == true || aiWinsCampaign == true) return;
        if (pauseOn == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                canvasPause.SetActive(true);
                pauseOn = true;
                return;
            }
        }
        if (pauseOn == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                canvasPause.SetActive(false);
                pauseOn = false;
                return;
            }
        }
    }


    // Game Modes

    private void GameModes()
    {
        if (GameMode.GameModeCampaign == true) 
        {
            PlayerWinCampaign();
            AIWinCampaign();
        }
        if (GameMode.GameModeEndless == true)
        {
            PlayerWinEndless();
            AIWinEndless();
        }
        if (GameMode.GameModeLives == true)
        {
            PlayerWin();
            AIWin();
        }
    }

    private void PlayerWinCampaign()
    {
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {   
            playerWins = true;
            playerWinsCampaign = true;
            StartCoroutine(LoadNextLevel(3f));
        }
    }

    private void AIWinCampaign()
    {
        if (transform.position.x < -9)
        {
            isSaved = true;
            aiWinsCampaign = true;
            aiWinsLives = false;
            aiWinsEndless = false;
            StartCoroutine(LoadFirstLevelAfterDelay(3f));
        }
    }

    public void PlayerWinEndless()
    {
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            playerWins = true;
            playerWinsEndless = true;
            
            StartCoroutine(LoadLevelAfterDelay(3f));
        }
    }


    public void AIWinEndless()
    {
        if (transform.position.x < -9)
        {
            isSaved = true;
            aiWins = true;
            aiWinsEndless = true;
            aiWinsCampaign = false;
            aiWinsLives = false;
            StartCoroutine(LoadLevelAfterDelay(3f));
        }
    }

    public void PlayerWin()
    {
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            playerWins = true;
            playerWinsLives = true;
            if (ScoreData.PlayerScore == 5)
            {
                StartCoroutine(WinScreenPlayer(2f));
            }
            if (ScoreData.PlayerScore <= 3)
            {
                StartCoroutine(LoadLevelAfterDelay(3f));
            }
        }
    }

    public void AIWin()
    {
        if (transform.position.x < -9)
        {
            isSaved = true;
            aiWins = true;
            aiWinsLives = true;
            aiWinsCampaign = false;
            aiWinsEndless = false;
            if (ScoreData.AiScore >= 5)
            {
                StartCoroutine(DefeatScreenAI(2f));
            }
            if (ScoreData.AiScore < 4)
            {
                StartCoroutine(LoadLevelAfterDelay(3f));
            }
        }
    }

    //Coroutines

    IEnumerator LoadFirstLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
        if (isSaved == true) {SaveScore(); }
        isSaved = false;
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        print("score: "+ ScoreData.AiScore);
        SceneManager.LoadScene(1);
        if (isSaved == true) { SaveScore(); }
        isSaved = false;
    }

    IEnumerator WinScreenPlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasGameWon.SetActive(true);
        if (isSaved == true) { SaveScore(); }
        isSaved = false;
    }

    IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        float sceneID = SceneManager.GetActiveScene().buildIndex;
        sceneID = sceneID + 1;
        SceneManager.LoadScene(sceneID.ToString());
        if (isSaved == true) { SaveScore(); }
        isSaved = false;
    }


    IEnumerator DefeatScreenAI(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasGameOver.SetActive(true);
        if (isSaved == true) { SaveScore(); }
        isSaved = false;
    }


    // Ball Collision

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (playerWins == true || aiWins == true || aiWinsCampaign == true) return;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        if (col.gameObject.name == "PaddleLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "AIPaddle")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
