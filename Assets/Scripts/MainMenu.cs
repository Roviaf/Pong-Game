using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    bool aiDifficultyEasy = false;
    bool aiDifficultyNormal = false;
    bool aiDifficultyHard = false;
    bool aiDifficultyInsane = false;

    bool gamemodeLives = false;
    bool gamemodeEndless = false;
    bool gamemodeCampaign = false;

    bool singlePlayer = false;
    bool multiPlayer = false;
    bool highScores = false;
    bool options = false;
    bool backSPlayer = false;
    bool backOptions = false;
    bool backMPlayer = false;
    bool backHighscores = false;
    bool backDifficulties = false;

    GameObject faderObject;
    bool mFaded = true;
    public float Duration = 0.4f;


    GameObject canvasMainMenu;
    GameObject canvasSinglePlayerMenu;
    GameObject aiDifficulty;
    GameObject canvasPause;
    GameObject canvasOptions;
    GameObject canvasHighscore;

    private void Start() 
    {
        KeyBiddings.WSkey = 1;

        aiDifficultyEasy = false;
        aiDifficultyNormal = false;
        aiDifficultyHard = false;
        aiDifficultyInsane = false;
        gamemodeLives = false;
        gamemodeEndless = false;
        gamemodeCampaign = false;
        singlePlayer = false;
        multiPlayer = false;
        highScores = false;
        options = false;
        backSPlayer = false;
        backOptions = false;
        backMPlayer = false;
        backHighscores = false;
        backDifficulties = false;
        mFaded = true;



        if (GameObject.FindWithTag("PauseMenu") != null) 
        {
            canvasPause = GameObject.FindWithTag("PauseMenu");
            canvasPause.SetActive(false);
        }

        faderObject = GameObject.FindWithTag("Fader");
        canvasMainMenu = GameObject.FindWithTag("MainMenu");
        canvasSinglePlayerMenu = GameObject.FindWithTag("SinglePlayerMenu");
        aiDifficulty = GameObject.FindWithTag("DifficultyMenu");
        canvasOptions = GameObject.FindWithTag("Options");
        canvasHighscore = GameObject.FindWithTag("Highscore");

        canvasSinglePlayerMenu.SetActive(false);
        aiDifficulty.SetActive(false);
        canvasOptions.SetActive(false);
        canvasHighscore.SetActive(false);

        LoadScore();
        print(ScoreData.AICampaignScore);
    }

    // LOAD

    public void LoadScore()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null) return;
        ScoreData.AICampaignScore = data.highscoreAIcampaign;
        ScoreData.AIEndlessScore = data.highscoreAIEndless;
        ScoreData.AILivesScore = data.highscorelivesAI;

        ScoreData.PlayerCampaignScore = data.highscoreplayercampaign;
        ScoreData.PlayerEndlessScore = data.highscoreplayerEndless;
        ScoreData.PlayerLivesScore = data.highscorelivesplayer;

    }

    // Options on menu for fader
    public void SinglePlayerOption(){singlePlayer = true;}
    public void MultiPlayerOption(){multiPlayer = true;}
    public void HighScoresOption(){highScores = true;}
    public void OptionsOption(){options = true;}

    public void BackInsideSPlayer(){backSPlayer = true;}
    public void BackinsideOptions(){backOptions = true;}
    public void BackInsideMPlayer(){backMPlayer = true;}
    public void BackInsideHighscores(){backHighscores = true;}

    // FADER

    public void Fader()
    {
        var canvasgroup = faderObject.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvasgroup, canvasgroup.alpha, mFaded ? 1 : 0));
    }

    public IEnumerator DoFade(CanvasGroup canvasgroup, float start, float end)
    {
        Time.timeScale = 1;
        float counter = 0f;
        canvasgroup.GetComponent<Canvas>().sortingOrder = 1;
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvasgroup.alpha = Mathf.Lerp (start, end, counter / Duration);
            yield return null;
        }

        if (singlePlayer == true)
        {
            singlePlayer = false;
            canvasMainMenu.SetActive(false);
            canvasSinglePlayerMenu.SetActive(true);
        }

        if (gamemodeCampaign == true || gamemodeEndless == true || gamemodeLives == true)
        { canvasSinglePlayerMenu.SetActive(false); aiDifficulty.SetActive(true); }

        if (multiPlayer == true){}
        if (highScores == true)
        {
            highScores = false;
            canvasMainMenu.SetActive(false); canvasHighscore.SetActive(true);
            Text textCampaign = GameObject.Find("CampaignScore").GetComponent<Text>();
            Text textEndless = GameObject.Find("EndlessScore").GetComponent<Text>();
            Text textLives = GameObject.Find("LivesScore").GetComponent<Text>();
            textCampaign.text = ScoreData.AICampaignScore.ToString() + " Time(s)";
            textEndless.text = ScoreData.AIEndlessScore.ToString() + " Time(s)";
            textLives.text = ScoreData.AILivesScore.ToString() + " Live(s)";
        }

        if (options == true)
        {
            options = false; 
            canvasMainMenu.SetActive(false); canvasOptions.SetActive(true); canvasOptions.GetComponent<Canvas>().sortingOrder = 0; 
        }

        if (backHighscores == true) 
        {
            backHighscores = false;
            canvasHighscore.SetActive(false); canvasMainMenu.SetActive(true);
        }

        if (backSPlayer == true)
        {
            backSPlayer = false;
            canvasSinglePlayerMenu.SetActive(false); canvasMainMenu.SetActive(true);
        }

        if (backOptions == true)
        {
            backOptions = false;
            canvasOptions.SetActive(false); canvasMainMenu.SetActive(true);
        }

        if (mFaded == true)
        {
            float counter2 = 0f;
            while (counter2 < Duration)
            {
                counter2 += Time.deltaTime;
                canvasgroup.alpha = Mathf.Lerp(1, 0, counter2 / Duration);
                yield return null;
            }
            canvasgroup.GetComponent<Canvas>().sortingOrder = 0;
            if (gamemodeCampaign == true || gamemodeEndless == true || gamemodeLives == true)
            { aiDifficulty.GetComponent<Canvas>().sortingOrder = 1;}
        }
    }

    // GAME MODES

    public void GameModeLives()
    {
        gamemodeLives = true;
        GameMode.GameModeLives = gamemodeLives;
    }

    public void GameModeEndless()
    {
        gamemodeEndless = true;
        GameMode.GameModeEndless = gamemodeEndless;
    }

    public void GameModeCampaign()
    {
        gamemodeCampaign = true;
        GameMode.GameModeCampaign = gamemodeCampaign;
    }

    // DIFFICULTIES

    public void AIDifficultyEasy()
    {
        aiDifficultyEasy = true;
        AIDifficulty.AISpeed = 3f;
        AIDifficulty.BallDistance = 6f;
        AIDifficulty.BallSpeed = 5f;
        SceneManager.LoadScene(1);
    }
    public void AIDifficultyNormal()
    {
        aiDifficultyNormal = true;
        AIDifficulty.AISpeed = 5f;
        AIDifficulty.BallDistance = 8f;
        AIDifficulty.BallSpeed = 7f;
        SceneManager.LoadScene(1);
    }
    public void AIDifficultyHard()
    {
        aiDifficultyHard = true;
        AIDifficulty.AISpeed = 8f;
        AIDifficulty.BallDistance = 11f;
        AIDifficulty.BallSpeed = 9f;
        SceneManager.LoadScene(1);
    }
    public void AIDifficultyInsane()
    {
        aiDifficultyInsane = true;
        AIDifficulty.AISpeed = 11f;
        AIDifficulty.BallDistance = 13f;
        AIDifficulty.BallSpeed = 12f;
        SceneManager.LoadScene(1);
    }

    //KEYBIDDINGS
    public void KeyBiddingWS()
    {
        KeyBiddings.UPDOWN = 0;
        KeyBiddings.WSkey = 1;
    }
    public void KeyBiddingUpDown()
    {
        KeyBiddings.UPDOWN = 1;
        KeyBiddings.WSkey = 0;
    }

    // QUIT BUTTON

    public void Quit()
    {
        Debug.Log("I quitted");
        Application.Quit();
    }
}
