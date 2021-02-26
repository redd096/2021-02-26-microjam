using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [Header("Commands")]
    [SerializeField] KeyCode rightInput = KeyCode.RightArrow;
    [SerializeField] KeyCode leftInput = KeyCode.LeftArrow;

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
            rb.AddTorque(-speedRotation, ForceMode2D.Impulse);
        }
        //or left to rotate on left
        else if(Input.GetKeyDown(leftInput))
        {
            rb.AddTorque(speedRotation, ForceMode2D.Impulse);
        }
    }
}
