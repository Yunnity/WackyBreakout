using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Help:
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Gameplay:
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.GameBad:
                SceneManager.LoadScene("GameOverBadEnd");
                break;
            case MenuName.GameGood:
                SceneManager.LoadScene("GameOverGoodEnd");
                break;
        }
    }
}
