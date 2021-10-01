using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    public static bool speedTimerRunning;
    public static float speedFactor;
    public static float remainingTime;

    public static bool SpeedTimerRunning
    {
        get { return GetSpeedUpEffectMonitor().SpeedTimerRunning; }
    }

    public static float SpeedFactor
    {
        get { return GetSpeedUpEffectMonitor().SpeedUpValue; }
    }

    public static float RemainingTime
    {
        get { return GetSpeedUpEffectMonitor().RemainingTime; }
    }

    static SpeedUpEffectMonitor GetSpeedUpEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedUpEffectMonitor>();
    }
}
