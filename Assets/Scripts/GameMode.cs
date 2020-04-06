using System;

public static class GameMode
{
    private static bool gameModeCampaign, gameModeEndless, gameModeLives;

    public static bool GameModeCampaign
    {
        get
        {
            return gameModeCampaign;
        }
        set
        {
            gameModeCampaign = value;
        }
    }
    public static bool GameModeEndless
    {
        get
        {
            return gameModeEndless;
        }
        set
        {
            gameModeEndless = value;
        }
    }
    public static bool GameModeLives
    {
        get
        {
            return gameModeLives;
        }
        set
        {
            gameModeLives = value;
        }
    }
}