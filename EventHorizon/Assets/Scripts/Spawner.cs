using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Fuel fuel;

    //public GameOb spawnee;
    GameObject obstacle;
    public GameObject fuelGem;
    public GameObject[] obstacles;
    public bool stopSpawing = false;
    bool triggerSpawn;
    float spawnTime = .05f;
    float spawnDelay = 3.5f;

    //Speed stuff
    float objectSpeed;
    float difficultyObstacleSpeed;
    float overdriveSpeed = 2f;

    Vector3 spawnPoint; //point 
    string[] spawnObjects = { "obstacle", "gem", "obstacle", "obstacle" }; //holds all possible items that can be spawned
    float[] xSpawnPoints = { -20f, -10f, 0f, 10f, 20f };
    int randSpawnPoint; //index of randomly chosen spawn point
    int randSpawnObject; // index of randomy chosen spawn object

    void Start()
    {
        triggerSpawn = true;
        objectSpeed = 30;
        spawnPoint = new Vector3(0, .6f, -15f);
        StartCoroutine("Spawn");
        //fuelGem = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelGem>();
        //obstacle = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Obstacle>();
        //InvokeRepeating("SpawnRow", spawnTime, spawnDelay);
    }


    IEnumerator Spawn()
    {
        for (; ; )
        {
            SpawnRow();
            triggerSpawn = false;
            yield return new WaitForSeconds((spawnDelay));
        }
    }


    public void SpawnRow()
    {
        int[] lanePopulation = new int[5] { 0, 0, 0, 0, 0 };
        int numObstacles;
        int obstacles = 0;
        int lane;
        bool isEmpty;

        if (GetSpeed() < 50)
        {
            numObstacles = Random.Range(3, 4);
            while (obstacles < numObstacles)
            {
                lane = Random.Range(0, 5);
                isEmpty = (lanePopulation[lane] == 0);
                if (isEmpty)
                {
                    randSpawnObject = Random.Range(0, spawnObjects.Length-1); //randomly select from objects
                    //indicates lane is now occupied
                    lanePopulation[lane] = randSpawnObject;
                    spawnPoint.x = xSpawnPoints[lane];
                    //spawns corresponding object
                    SpawnObject(spawnObjects[randSpawnObject]);
                    obstacles++;
                }
            }
        }
        else
        {
            numObstacles = Random.Range(1, 4);


            while (obstacles < numObstacles)
            {
                lane = Random.Range(0, 5);
                isEmpty = (lanePopulation[lane] == 0);
                if (isEmpty)
                {
                    randSpawnObject = Random.Range(0, spawnObjects.Length); //randomly select from objects
                    //indicates lane is now occupied
                    lanePopulation[lane] = randSpawnObject;
                    spawnPoint.x = xSpawnPoints[lane];
                    //spawns corresponding object
                    SpawnObject(spawnObjects[randSpawnObject]);
                    obstacles++;
                }
            }
        }
        if (stopSpawing)
        {
            CancelInvoke("SpawnRow");
        }
    }

    public void SpawnObject(string objectName)
    {
        switch (objectName)
        {
            case "obstacle":
                spawnPoint.y = 1.5f;
                int chosenObstacle = Random.Range(0, obstacles.Length); //get random obstacle
                obstacle = obstacles[chosenObstacle]; //assign to obstacle that will spawn
                GameObject newObstacle = Instantiate(obstacle, spawnPoint, transform.rotation);
                newObstacle.GetComponent<Obstacle>().SetSpeed(GetSpeed());

                break;
            case "gem":
                spawnPoint.y = 0.6f;
                GameObject newGem = Instantiate(fuelGem, spawnPoint, transform.rotation);
                newGem.GetComponent<FuelGem>().SetSpeed(GetSpeed());
                break;
        }
    }

    //Delays or speeds up the spawn of the next section of obstacles/fuel
    public void Delay(float delay)
    {
        spawnDelay *= delay;
        //if (spawnDelay <= 0)
        //{
        //    spawnDelay += .05f;
        //}
    }

    public void IncrementDifficultySpeed()
    {
        difficultyObstacleSpeed += 2;
    }

    //returns the speed of objects being spawned either during overdrive or not
    public float GetSpeed()
    {
        if (fuel.OverdriveStatus())
        {
            objectSpeed = (30 + difficultyObstacleSpeed) * overdriveSpeed;
        }
        else
        {
            objectSpeed = 30 + difficultyObstacleSpeed;
        }

        return objectSpeed;
    }

}
