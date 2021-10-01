using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rgb2d;
    float colliderHalfWidth;
    float colliderHalfHeight;
    const float BounceAngleHalfRange = Mathf.PI / 3;
    bool paddleFrozen = false;
    Timer freezeTimer;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = gameObject.GetComponent<Rigidbody2D>();
        colliderHalfWidth = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
        colliderHalfHeight = gameObject.GetComponent<BoxCollider2D>().size.y / 2;
        freezeTimer = gameObject.AddComponent<Timer>();
        EventManager.AddListener(HandleFreezeEventInvoked);
        freezeTimer.AddTimerEventListener(FreezeTimerDone);
    }

    float CalculateClampedX(float xPosition)
    {
        if((xPosition - colliderHalfWidth) < ScreenUtils.ScreenLeft)
        {
            return ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if((xPosition + colliderHalfWidth) > ScreenUtils.ScreenRight)
        {
            return ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        else
        {
            return xPosition;
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && bounceOnTop(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                colliderHalfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool bounceOnTop(Collision2D coll)
    {
        if((coll.gameObject.transform.position.y - colliderHalfHeight) > transform.position.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void FixedUpdate()
    {
        if (!paddleFrozen)
        {
            float horizMove = Input.GetAxis("Horizontal");
            if (horizMove != 0)
            {
                Vector2 xMove = new Vector2(rgb2d.position.x + (horizMove * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime),
                    rgb2d.position.y);
                xMove.x = CalculateClampedX(xMove.x);
                rgb2d.MovePosition(xMove);
            }
        }
    }

    void HandleFreezeEventInvoked(float duration)
    {
        paddleFrozen = true;
        if(!freezeTimer.Running)
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else
        {
            freezeTimer.AddTime(duration);
        }
    }

    void FreezeTimerDone()
    {
        paddleFrozen = false;
    }
}
