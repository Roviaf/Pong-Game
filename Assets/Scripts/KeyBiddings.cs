using System;

public static class KeyBiddings
{
    private static float WS, UpDown;

    public static float WSkey
    {
        get
        {
            return WS;
        }
        set
        {
            WS = value;
        }
    }
    public static float UPDOWN
    {
        get
        {
            return UpDown;
        }
        set
        {
            UpDown = value;
        }
    }
}