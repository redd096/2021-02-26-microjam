using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void EndGame()
    {
        //freeze time
        Time.timeScale = 0;
    }
}
