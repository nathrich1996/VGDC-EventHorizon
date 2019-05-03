using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
     GameObject spawnee;
    public GameObject[] obstacles;
    public bool stopSpawing = false;
    public float spawnTime;
    public float spawnDelay;
    float timer;

    void Start()
    {
        SpawnObject();
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=3.0f)
        {
            SpawnObject();
            timer = 0;
        }
    }
    public void SpawnObject()
    {
        int chosenSpawnee = Random.Range(0, obstacles.Length);
        spawnee = obstacles[chosenSpawnee];
        Instantiate(spawnee, transform.position, transform.rotation);
       
    }
}
