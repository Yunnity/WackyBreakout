using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected float points;
    PointsAddedEvent pointsAddedEvent;
    BlockDestroyedEvent blockDestroyedEvent;

    protected virtual void Start()
    {
        pointsAddedEvent = new PointsAddedEvent();
        blockDestroyedEvent = new BlockDestroyedEvent();
        points = ConfigurationUtils.StandardPoints;
        EventManager.AddPointInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }

    public void AddPointsAddedListener(UnityAction<float> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    public void AddDestructionListener(UnityAction listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        pointsAddedEvent.Invoke(points);
        blockDestroyedEvent.Invoke();
    }
}
