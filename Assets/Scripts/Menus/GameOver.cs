using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    const string scorePretext = "Final Score: ";
    static Text finalScore;
    float score;

    void Start()
    {
        finalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>();
        score = HUD.score;
        finalScore.text = scorePretext + score.ToString();
    }

    public void HandleRetryButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Gameplay);
    }

    public void HandleQuitButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
