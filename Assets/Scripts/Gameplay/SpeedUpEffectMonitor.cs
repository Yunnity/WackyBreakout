using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffectMonitor : MonoBehaviour
{
    float speedUpValue;
    static public Timer speedTimer;

    public bool SpeedTimerRunning
    {
        get { return speedTimer.Running; }
    }

    public float RemainingTime
    {
        get { return speedTimer.RemainingTime; }
    }

    public float SpeedUpValue
    {
        get { return speedUpValue; }
    }

    // Start is called before the first frame update
    void Start()
    {
        speedTimer = gameObject.AddComponent<Timer>();
        EventManager.AddTwoArgListener(HandleSpeedEventInvoked);
        speedTimer.AddTimerEventListener(SpeedUpTimerDone);
    }

    void HandleSpeedEventInvoked(float speedLength, float speedUpValue)
    {
        if (!speedTimer.Running)
        {
            this.speedUpValue = speedUpValue;
            speedTimer.Duration = speedUpValue;
            speedTimer.Run();
        }
        else
        {
            speedTimer.AddTime(speedLength);
        }
    }

    void SpeedUpTimerDone()
    {
        speedTimer.Stop();
        speedUpValue = 1;
    }
}
