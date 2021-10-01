using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    float angle;
    Rigidbody2D rgb2d;
    Timer timer;
    BallSpawner ballSpawner;
    bool stallBall = true;
    public static float ballWidth;
    public static float ballHeight;
    Timer speedTimer;
    float speedUpAmount;
    bool ballSpedUp;
    BallFellEvent ballFellEvent;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D tempBall = gameObject.GetComponent<BoxCollider2D>();
        ballWidth = tempBall.size.x;
        ballHeight = tempBall.size.y;

        ballSpawner = Camera.main.GetComponent<BallSpawner>();
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallLifeSpan;
        timer.Run();

        speedTimer = gameObject.AddComponent<Timer>();
        speedUpAmount = ConfigurationUtils.SpeedValue;
        EventManager.AddTwoArgListener(HandleSpeedEventInvoked);
        rgb2d = gameObject.GetComponent<Rigidbody2D>();

        ballFellEvent = new BallFellEvent();
        EventManager.AddBallInvoker(this);

        timer.AddTimerEventListener(BallLifeSpanDone);
        speedTimer.AddTimerEventListener(SpeedTimerDone);
    }

    public void SetDirection(Vector2 newDirection)
    {
        float speed = rgb2d.velocity.magnitude;
        rgb2d.velocity = newDirection * speed;
    }

    void Update()
    {
        if (!timer.Stall && stallBall)
        {
            angle = Random.Range(-2 * Mathf.PI / 3, -Mathf.PI / 6);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if(EffectUtils.SpeedTimerRunning)
            {
                rgb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce * EffectUtils.SpeedFactor, ForceMode2D.Impulse);
                ballSpedUp = true;
                speedTimer.Duration = speedTimer.RemainingTime;
                speedTimer.Run();
            }
            else
            {
                rgb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
                ballSpedUp = false;
            }
            stallBall = false;
        }
        if (transform.position.y < (LevelBuilder.newPaddle.transform.position.y - LevelBuilder.newPaddle.GetComponent<BoxCollider2D>().size.y / 2))
        {
            Destroy(gameObject);
            ballFellEvent.Invoke();
        }
    }

    void HandleSpeedEventInvoked(float speedLength, float speedUpValue)
    {

        if (!speedTimer.Running && !ballSpedUp)
        {
            StartSpeedUp(speedLength, speedUpValue);
            rgb2d.velocity *= speedUpValue;
        }
        else
        {
            speedTimer.AddTime(speedLength);
        }
    }

    void StartSpeedUp(float speedLength, float speedUpValue)
    {
        speedTimer.Duration = speedLength;
        speedTimer.Run();
        ballSpedUp = true;
    }

    public void AddBallFellEventListener(UnityAction listener)
    {
        ballFellEvent.AddListener(listener);
    }

    void BallLifeSpanDone()
    {
        Vector3 location = new Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight),
            Random.Range((ScreenUtils.ScreenBottom / 4), (ScreenUtils.ScreenBottom / 3)), -Camera.main.transform.position.z);
        if (Physics2D.OverlapArea(new Vector2(location.x - (Ball.ballWidth / 2), location.y - (Ball.ballHeight / 2)),
            new Vector2(location.x + (Ball.ballWidth / 2), location.y + (Ball.ballHeight / 2))) == null)
        {
            gameObject.transform.position = location;
            rgb2d.velocity = Vector2.zero;
            stallBall = true;
            timer.Duration = ConfigurationUtils.BallLifeSpan;
            timer.Run();
        }
    }

    void SpeedTimerDone()
    {
        speedTimer.Stop();
        rgb2d.velocity /= speedUpAmount;
        ballSpedUp = false;
    }
}
