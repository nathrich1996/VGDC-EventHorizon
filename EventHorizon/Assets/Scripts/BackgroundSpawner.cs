using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public GameObject[] obstacles;
    public bool stopSpawing = false;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        int chosenSpawnee = Random.Range(0, obstacles.Length);
        spawnee = obstacles[chosenSpawnee];
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawing)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
