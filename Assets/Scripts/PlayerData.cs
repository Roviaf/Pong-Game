
[System.Serializable]
public class PlayerData
{
    public int highscoreplayercampaign, highscoreAIcampaign, 
    highscoreplayerEndless, highscoreAIEndless, highscorelivesplayer, highscorelivesAI;

    public PlayerData ()
    {
        if (highscoreplayercampaign < ScoreData.PlayerCampaignScore)
        {highscoreplayercampaign = ScoreData.PlayerCampaignScore;}

        if (highscoreplayerEndless < ScoreData.PlayerEndlessScore)
        { highscoreplayerEndless = ScoreData.PlayerEndlessScore; }

        if (highscorelivesplayer < ScoreData.PlayerLivesScore)
        { highscorelivesplayer = ScoreData.PlayerLivesScore; }


        if (highscoreAIcampaign < ScoreData.AICampaignScore)
        {highscoreAIcampaign = ScoreData.AICampaignScore; }

        if (highscoreAIEndless < ScoreData.AIEndlessScore)
        {highscoreAIEndless = ScoreData.AIEndlessScore; }
        
        if (highscorelivesAI < ScoreData.AILivesScore)
        {highscorelivesAI = ScoreData.AILivesScore; }
    }
}