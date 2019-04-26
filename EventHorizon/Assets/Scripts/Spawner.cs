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

    //Speed stuff
    
    [HideInInspector]
    public bool overdriveActive;
    public float difficultyObstacleSpeed = 0;

    Vector3 spawnPoint; //spawn position of first object
    Vector3 spawnPoint2; //spawn position of next object

    string chosenSpawnObject; //first object
    string chosenSpawnObject2;//second object
    string[] spawnObjects =  { "obstacle","gem"}; //holds all possible items that can be spawned
    float[] xSpawnPoints = { -20f, -10f, 0f, 10f, 20f };


    void Start() {
        spawnPoint = new Vector3(0,.6f,-15f);
        //fuelGem = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelGem>();
        //obstacle = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Obstacle>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    public void GetSpawnPointandObject()
    {
        int randSpawnPoint; //index of randomly chosen spawn point
        int randSpawnPoint2;
        int randSpawnObject; // index of randomy chosen spawn object
        int randSpawnObject2;
        
        randSpawnPoint = Random.Range(0,xSpawnPoints.Length); //randomly select from spawn points
        randSpawnObject = Random.Range(0, spawnObjects.Length); //randomly select from objects

       

        randSpawnPoint2 = Random.Range(0, xSpawnPoints.Length); //randomly select from spawn points
        randSpawnObject2 = Random.Range(0, spawnObjects.Length); //randomly select from objects
        while (randSpawnPoint == randSpawnPoint2) // if they share the same spawn point
            randSpawnPoint2 = Random.Range(0, xSpawnPoints.Length); //randomly choose a different spawnpoint

        //set spawn points and objects
        spawnPoint.x = xSpawnPoints[randSpawnPoint];
        chosenSpawnObject = spawnObjects[randSpawnObject];
        spawnPoint2.x = xSpawnPoints[randSpawnPoint2];
        chosenSpawnObject2 = spawnObjects[randSpawnObject2];
    }

    public void SpawnObject() {
        GetSpawnPointandObject();
        switch (chosenSpawnObject)
        {
            case "obstacle":
                spawnPoint.y = 1.5f;
                GameObject newObstacle = Instantiate(obstacle, spawnPoint, transform.rotation);
                if (overdriveActive)
                    newObstacle.GetComponent<Obstacle>().SetSpeed(25 + difficultyObstacleSpeed);
                else
                    newObstacle.GetComponent<Obstacle>().SetSpeed(40 + difficultyObstacleSpeed);
                break;
            case "gem":
                spawnPoint.y = 0.6f;
                GameObject newGem = Instantiate(fuelGem, spawnPoint, transform.rotation);
                if (overdriveActive)
                    newGem.GetComponent<FuelGem>().SetSpeed(25 + difficultyObstacleSpeed);
                else
                    newGem.GetComponent<FuelGem>().SetSpeed(40 + difficultyObstacleSpeed);
                break;
        }
        switch (chosenSpawnObject2)
        {
            case "obstacle":
                spawnPoint2.y = 1.5f;
                GameObject newObstacle2 = Instantiate(obstacle, spawnPoint2, transform.rotation);
                if (overdriveActive)
                    newObstacle2.GetComponent<Obstacle>().SetSpeed(25 + difficultyObstacleSpeed);
                else
                    newObstacle2.GetComponent<Obstacle>().SetSpeed(40 + difficultyObstacleSpeed);
                break;
            case "gem":
                spawnPoint2.y = 0.6f;
                GameObject newGem2 = Instantiate(fuelGem, spawnPoint2, transform.rotation);
                if (overdriveActive)
                    newGem2.GetComponent<FuelGem>().SetSpeed(25 + difficultyObstacleSpeed);
                else
                    newGem2.GetComponent<FuelGem>().SetSpeed(40 + difficultyObstacleSpeed);
                break;
        }
        //Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawing) {
            CancelInvoke("SpawnObject");
        }
    }
    public void ShortenDelay(float delay)
    {
        spawnDelay -= delay;
        if (spawnDelay <= 0)
        {
            spawnDelay += .1f;
        }
    }
}
  