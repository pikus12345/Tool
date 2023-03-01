using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersMovement : MonoBehaviour
{
    public float moveSpeed;
    private void FixedUpdate()
    {
        if (GameManager.IsGameRunning)
        {
            Move();
        }
    }
    public void Move()
    {
        transform.Translate(0,-Time.fixedDeltaTime * moveSpeed, 0);
    }
}
