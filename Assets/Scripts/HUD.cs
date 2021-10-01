using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Text scoreText;
    static Text ballsText;

    public static float score;
    public static string scorePretext = "Score: ";
    public static float ballsRemaining;
    public static string ballsPretext = "Balls Left: ";

    // Start is called before the first frame update
    void Start()
    {
        ballsRemaining = ConfigurationUtils.BallsLeft;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = scorePretext + score.ToString();
        ballsText = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        ballsText.text = ballsPretext + ballsRemaining.ToString();
        EventManager.AddPointsAddedListener(AddPoints);
        EventManager.AddBallFellListener(BallGone);
    }

    public static void AddPoints(float points)
    {
        score += points;
        scoreText.text = scorePretext + score.ToString();
    }

    public static void BallGone()
    {
        ballsRemaining -= 1;
        if(ballsRemaining < 0)
        {
            MenuManager.GoToMenu(MenuName.GameBad);
        }
        ballsText.text = ballsPretext + ballsRemaining.ToString();
    }
}
