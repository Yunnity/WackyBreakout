using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static PickUpBlock invoker;
    static UnityAction<float> listener;

    static List<PickUpBlock> speedupEventInvokers = new List<PickUpBlock>();
    static List<UnityAction<float, float>> speedupEventListeners =
        new List<UnityAction<float, float>>();

    static Block pointInvoker;
    static UnityAction<float> pointListener;

    static Ball ballInvoker;
    static UnityAction ballFellListener;

    static Block destructionInvoker;
    static UnityAction blockDestructionListener;

    public static void AddInvoker(PickUpBlock script)
    {
        invoker = script;
        if (listener != null)
        {
            invoker.AddFreezeEventListener(listener);
        }
    }

    public static void AddListener(UnityAction<float> oneArgListener)
    {
        listener = oneArgListener;
        //invoker?.AddFreezeEventListener(listener);
        if(invoker != null)
        {
            invoker.AddFreezeEventListener(listener);
        }
    }

    public static void AddSpeedInvoker(PickUpBlock invoker)
    {
        speedupEventInvokers.Add(invoker);
        foreach(UnityAction<float, float> speedupEventListener in speedupEventListeners)
        {
            invoker.AddSpeedEventListener(speedupEventListener);
        }
    }

    public static void AddTwoArgListener(UnityAction<float, float> twoArgListener)
    {
        speedupEventListeners.Add(twoArgListener);
        foreach(PickUpBlock invoker in speedupEventInvokers)
        {
            invoker.AddSpeedEventListener(twoArgListener);
        }
    }

    public static void AddPointInvoker(Block invoker)
    {
        pointInvoker = invoker;
        if(pointInvoker != null)
        {
            pointInvoker.AddPointsAddedListener(pointListener);
        }
    }

    public static void AddPointsAddedListener(UnityAction<float> listener)
    {
        pointListener = listener;
        if(pointInvoker != null)
        {
            pointInvoker.AddPointsAddedListener(pointListener);
        }
    }

    public static void AddBallInvoker(Ball invoker)
    {
        ballInvoker = invoker;
        if(ballInvoker != null)
        {
            ballInvoker.AddBallFellEventListener(ballFellListener);
        }
    }

    public static void AddBallFellListener(UnityAction listener)
    {
        ballFellListener = listener;
        if(ballInvoker != null)
        {
            ballInvoker.AddBallFellEventListener(ballFellListener);
        }
    }

    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        destructionInvoker = invoker;
        if(destructionInvoker != null)
        {
            destructionInvoker.AddDestructionListener(blockDestructionListener);
        }
    }

    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestructionListener = listener;
        if(destructionInvoker != null)
        {
            destructionInvoker.AddDestructionListener(blockDestructionListener);
        }
    }
}
