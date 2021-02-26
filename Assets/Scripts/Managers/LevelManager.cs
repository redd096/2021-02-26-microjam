using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

public class LevelManager : MonoBehaviour
{
    [Header("Important")]
    [SerializeField] float delayEverySpawn = 3;
    [SerializeField] Wall[] wallPrefabs = default;

    float timerSpawn;
    int score;

    void Start()
    {
        //default time
        timerSpawn = Time.time + delayEverySpawn;
    }

    void Update()
    {
        //if end spawn timer
        if(Time.time > timerSpawn)
        {
            //increase timer and spawn wall
            timerSpawn = Time.time + delayEverySpawn;
            SpawnWall();
        }
    }

    #region private API

    void SpawnWall()
    {
        //instantiate random wall
        Wall wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]);

        //spawn at random position
        wall.SpawnRandomPosition();
    }

    #endregion

    #region public API

    public void AddScore()
    {
        //add score and update UI
        score++;
        GameManager.instance.uiManager.SetScoreText(score);
    }

    public void EndGame()
    {
        //freeze time and lock player
        Time.timeScale = 0;
        GameManager.instance.player.enabled = false;

        //end menu
        GameManager.instance.uiManager.EndMenu(true);
    }

    #endregion
}
