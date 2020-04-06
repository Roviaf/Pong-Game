using System;

public static class AIDifficulty
{
    private static float aiSpeed, ballDistance, ballSpeed;

    public static float AISpeed
    {
        get
        {
            return aiSpeed;
        }
        set
        {
            aiSpeed = value;
        }
    }
    public static float BallDistance
    {
        get
        {
            return ballDistance;
        }
        set
        {
            ballDistance = value;
        }
    }
    public static float BallSpeed
    {
        get
        {
            return ballSpeed;
        }
        set
        {
            ballSpeed = value;
        }
    }
}