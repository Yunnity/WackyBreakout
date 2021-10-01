using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;
    Timer timer;
    

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        SpawnABall();
        timer.Duration = Random.Range(ConfigurationUtils.MinBallSpawn, ConfigurationUtils.MaxBallSpawn);
        timer.Run();
        timer.AddTimerEventListener(SpawnTimerDone);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    private void SpawnABall()
    {
        Vector3 location = new Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight),
            Random.Range((ScreenUtils.ScreenBottom / 4), (ScreenUtils.ScreenBottom / 3)), -Camera.main.transform.position.z);
        if (Physics2D.OverlapArea(new Vector2(location.x - (Ball.ballWidth / 2), location.y - (Ball.ballHeight / 2)),
            new Vector2(location.x + (Ball.ballWidth / 2), location.y + (Ball.ballHeight / 2))) == null)
        {
            Instantiate(prefabBall, location, Quaternion.identity);
        }
    }

    void SpawnTimerDone()
    {
        SpawnABall();
        timer.Duration = Random.Range(ConfigurationUtils.MinBallSpawn, ConfigurationUtils.MaxBallSpawn);
        timer.Run();
    }
}
