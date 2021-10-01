using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpBlock : Block
{
    [SerializeField]
    Sprite freezeSprite;
    [SerializeField]
    Sprite speedSprite;

    float freezeTime;
    PickupEffect blockType;
    FreezeEvent freezeEvent;
    SpeedEvent speedEvent;
    float speedTime;
    float speedValue;

    public PickupEffect BlockType
    {
        set
        {
            blockType = value;
            if (blockType == PickupEffect.Freezer)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = freezeSprite;
                freezeTime = ConfigurationUtils.FreezeTime;
                freezeEvent = new FreezeEvent();
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = speedSprite;
                speedTime = ConfigurationUtils.SpeedDuration;
                speedValue = ConfigurationUtils.SpeedValue;
            }
        }
    }

    public void AddFreezeEventListener(UnityAction<float> listener)
    {
        freezeEvent.AddListener(listener);
    }

    public void AddSpeedEventListener(UnityAction<float, float> twoArgsListener)
    {
        speedEvent.AddListener(twoArgsListener);
    }



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        points = ConfigurationUtils.PickUpPoints;
        freezeEvent = new FreezeEvent();
        speedEvent = new SpeedEvent();
        EventManager.AddInvoker(this);
        EventManager.AddSpeedInvoker(this);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(blockType == PickupEffect.Freezer)
        {
            freezeEvent.Invoke(freezeTime);
        }
        else
        {
            speedEvent.Invoke(speedTime, speedValue);
        }
        base.OnCollisionEnter2D(collision);
    }
}
