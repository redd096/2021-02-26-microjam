using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 2;

    Camera cam;
    Rigidbody2D rb;

    Vector2 direction;

    void OnEnable()
    {
        //get references
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        //move
        rb.velocity = direction * speed;
    }

    #region private API

    void SpawnWall(Vector3 position, Vector2 direction, Vector3 rotation)
    {
        //be sure z is 0
        position = cam.ViewportToWorldPoint(position);
        position.z = 0;

        //spawn at position and set direction
        transform.position = position;
        this.direction = direction;

        //set rotation
        transform.rotation = Quaternion.Euler(rotation);
    }

    #endregion

    #region public API

    public void SpawnRandomPosition()
    {
        //spawn at random position
        float random = Random.value;

        //0.25 - up
        if (random < 0.25f)
            SpawnWall(new Vector2(0.5f, 1.5f), Vector2.down, new Vector3(0, 0, 90));
        //0.5 - down
        else if (random < 0.5f)
            SpawnWall(new Vector2(0.5f, -0.5f), Vector2.up, new Vector3(0, 0, 90));
        //0.75 - left
        else if (random < 0.75f)
            SpawnWall(new Vector2(-0.5f, 0.5f), Vector2.right, Vector3.zero);
        //1 - right
        else
            SpawnWall(new Vector2(1.5f, 0.5f), Vector2.left, Vector3.zero);
    }

    #endregion
}
