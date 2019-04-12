using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameOb spawnee;
    public GameObject obstacle;
    public GameObject fuelGem;
    public bool stopSpawing = false;
    float spawnTime =2.0f;
    float spawnDelay = 2.0f;
    
    Vector3 spawnPoint; //point 
    string chosenSpawnObject;
    string[] spawnObjects =  { "obstacle","gem"}; //holds all possible items that can be spawned
    float[] xSpawnPoints = { -20f, -10f, 0f, 10f, 20f };
    int randSpawnPoint; //index of randomly chosen spawn point
    int randSpawnObject; // index of randomy chosen spawn object

    void Start() {
        spawnPoint = new Vector3(0,.6f,-15f);
        //fuelGem = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelGem>();
        //obstacle = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Obstacle>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    public void GetSpawnPointandObject()
    {
        randSpawnPoint = Random.Range(0,xSpawnPoints.Length); //randomly select from spawn points
        randSpawnObject = Random.Range(0, spawnObjects.Length); //randomly select from objects
        spawnPoint.x = xSpawnPoints[randSpawnPoint];
        chosenSpawnObject = spawnObjects[randSpawnObject];
    }

    public void SpawnObject() {
        GetSpawnPointandObject();
        switch (chosenSpawnObject)
        {
            case "obstacle":
                spawnPoint.y = 1.5f;
                Instantiate(obstacle, spawnPoint, transform.rotation);
                break;
            case "gem":
                spawnPoint.y = 0.6f;
                Instantiate(fuelGem, spawnPoint, transform.rotation);
                break;
        }
        //Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawing) {
            CancelInvoke("SpawnObject");
        }
    }
}
  