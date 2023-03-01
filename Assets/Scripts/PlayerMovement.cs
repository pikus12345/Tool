using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 startPosition;
    public void Initialize()
    {
        transform.position = startPosition;
    }
    void FixedUpdate()
    {
        if (GameManager.IsGameRunning)
        {
            Move();
        }
    }

    private void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        transform.Translate(hor*Time.fixedDeltaTime*moveSpeed/Time.timeScale,0,0);
    }
}
