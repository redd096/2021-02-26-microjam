using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

public class WallCollider : MonoBehaviour
{
    [Header("Important")]
    [SerializeField] bool canKillPlayer = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (canKillPlayer == false)
            return;

        //if hit player
        if (collision.GetComponentInParent<PlayerRotator>())
        {
            //call end game
            GameManager.instance.levelManager.EndGame();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (canKillPlayer)
            return;

        //if hit player
        if (collision.GetComponentInParent<PlayerRotator>())
        {
            //add score
            GameManager.instance.levelManager.AddScore();
        }

        //if hit limit of the scene
        if(collision.GetComponentInParent<LimitsManager>())
        {
            //get wall parent and check destroy
            GetComponentInParent<Wall>().CheckDestroyObject();
        }
    }
}
