using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
	#region Fields
	
	// timer duration
	float totalSeconds = 0;
	
	// timer execution
	float elapsedSeconds = 0;
	float remainingTime = 0;
	bool running = false;
	bool stall = true;

	TimerFinishedEvent timerFinishedEvent = new TimerFinishedEvent();
	#endregion
	
	#region Properties
	
	/// <summary>
	/// Sets the duration of the timer
	/// The duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
    {
		set
        {
			if (!running)
            {
				totalSeconds = value;
			}
		}
        get { return totalSeconds; }
	}
	
	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	//public bool Finished
	//{
	//	get { return started && !running; } 
	//}
	
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
		get { return running; }
	}

	public bool Stall
    {
		get { return stall; }
    }

	public float RemainingTime
    {
        get { return remainingTime; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {	
		// update timer and check for finished
		if (running)
        {
			elapsedSeconds += Time.deltaTime;
			remainingTime -= Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
				timerFinishedEvent.Invoke();
			}
			if(elapsedSeconds >= 1 && stall)
            {
				stall = false;
            }
		}
	}
	
	/// <summary>
	/// Runs the timer
	/// Because a timer of 0 duration doesn't really make sense,
	/// the timer only runs if the total seconds is larger than 0
	/// This also makes sure the consumer of the class has actually 
	/// set the duration to something higher than 0
	/// </summary>
	public void Run()
    {	
		// only run with valid duration
		if (totalSeconds > 0)
        {
			running = true;
			stall = true;
            elapsedSeconds = 0;
			remainingTime = Duration;
		}
	}

    public void Stop()
    {
		running = false;
    }

    public void AddTime(float addedDuration)
    {
		if(running)
        {
			float leftoverTime = totalSeconds - elapsedSeconds;
			float newDuration = leftoverTime + addedDuration;
			running = false;
			Duration = newDuration;
			Run();
        }
    }

	public void AddTimerEventListener(UnityAction listener)
    {
		timerFinishedEvent.AddListener(listener);
    }
	#endregion
}
