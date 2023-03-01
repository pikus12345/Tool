using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public Tool toolToDestroy;

    void FixedUpdate()
    {
        if (GameManager.IsGameRunning)
        {
            transform.Translate(0, -moveSpeed * Time.fixedDeltaTime, 0);
        }
        
    }
    public void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}