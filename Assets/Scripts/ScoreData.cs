using System;

public static class ScoreData
{
    private static int playerScore, aiScore, playerCampaignScore, playerEndlessScore, playerLivesScore, aiCampaignScore, aiEndlessScore, aiLivesScore;

    public static int PlayerScore
    {
        get
        {
            return playerScore;
        }
        set
        {
            playerScore = value;
        }
    }

    public static int PlayerCampaignScore
    {
        get
        {
            return playerCampaignScore;
        }
        set
        {
            playerCampaignScore = value;
        }
    }

    public static int PlayerEndlessScore
    {
        get
        {
            return playerEndlessScore;
        }
        set
        {
            playerEndlessScore = value;
        }
    }

    public static int PlayerLivesScore
    {
        get
        {
            return playerLivesScore;
        }
        set
        {
            playerLivesScore = value;
        }
    }


    public static int AiScore
    {
        get
        {
            return aiScore;
        }
        set
        {
            aiScore = value;
        }
    }

    public static int AICampaignScore
    {
        get
        {
            return aiCampaignScore;
        }
        set
        {
            aiCampaignScore = value;
        }
    }

    public static int AIEndlessScore
    {
        get
        {
            return aiEndlessScore;
        }
        set
        {
            aiEndlessScore = value;
        }
    }

    public static int AILivesScore
    {
        get
        {
            return aiLivesScore;
        }
        set
        {
            aiLivesScore = value;
        }
    }


}