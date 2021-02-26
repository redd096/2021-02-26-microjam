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

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //press right to rotate on right
        if(Input.GetKeyDown(rightInput))
        {
            rb.AddTorque(Vector3.right * speedRotation, ForceMode.Impulse);
        }
        //or left to rotate on left
        else if(Input.GetKeyDown(leftInput))
        {
            rb.AddTorque(Vector3.left * speedRotation, ForceMode.Impulse);
        }
    }
}
