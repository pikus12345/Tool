using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public List<Vector3> spawnPositions;
    public float spawnCooldown;
    private float timer;
    
    private void Update()
    {
        if (GameManager.IsGameRunning)
        {
            timer += Time.deltaTime;
            if (timer > spawnCooldown)
            {
                SpawnRandom();
                timer = 0;
            }
        }
    }

    public void SpawnRandom()
    {
        int objId = Random.Range(0, gameObjects.Count);
        int posId = Random.Range(0, spawnPositions.Count);
        Spawn(gameObjects[objId], spawnPositions[posId]);
    }
    public void Spawn(GameObject obj, Vector3 spawnPosition)
    {
        Instantiate(obj, spawnPosition, Quaternion.identity);
    }
}
