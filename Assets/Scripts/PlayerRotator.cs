using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

public class PlayerRotator : MonoBehaviour
{
    [Header("Commands")]
    [SerializeField] KeyCode rightInput = KeyCode.RightArrow;
    [SerializeField] KeyCode leftInput = KeyCode.LeftArrow;
    [SerializeField] KeyCode pauseInput = KeyCode.Escape;

    [Header("Rotation")]
    [SerializeField] float speedRotation = 30;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //press right to rotate on right
        if(Input.GetKeyDown(rightInput))
        {
            Rotate(-speedRotation);
        }
        //or left to rotate on left
        else if(Input.GetKeyDown(leftInput))
        {
            Rotate(speedRotation);
        }

        //press to pause or resume
        if(Input.GetKeyDown(pauseInput))
        {
            Pause();
        }
    }

    void Rotate(float speed)
    {
        //rotate object
        rb.AddTorque(speed, ForceMode2D.Impulse);
    }

    void Pause()
    {
        //resume
        if(Time.timeScale == 0)
        {
            SceneLoader.instance.ResumeGame();
        }
        //or pause game
        else
        {
            SceneLoader.instance.PauseGame();
        }
    }
}
