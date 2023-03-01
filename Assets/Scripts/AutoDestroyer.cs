using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [SerializeField]private float timeToDestroy;
    private float timer;
    private void Update()
    {
        if (timer > timeToDestroy)
        {
            Destroy(gameObject);
        }
        if (GameManager.IsGameRunning)
        {
            timer += Time.deltaTime;
        }
    }

}
