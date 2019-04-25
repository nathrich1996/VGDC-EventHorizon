using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Text fuelText;
    public int fuelMeter;
    float timer;
    int fuelLoss;
    float fuel_interval;
    public DeathMenu dm;
    public Spawner spawner;
    public Score score;
    public bool noFuel = false;
    public bool overdrive = false;
    float overdriveTimer = 0;
    float overdriveLimit = 5.0f;
    float overdriveSpeed = 40f;
    bool upgradeDifficulty = false;
    GameObject[] obstacles;
    GameObject[] gems;

    int nextDifficultyIncreaseScore = 1000;

    // Start is called before the first frame update
    void Start()
    {
        fuelMeter = 5;
        timer = 0f;
        fuelLoss = 1;
        fuel_interval = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (score.score > nextDifficultyIncreaseScore) //Make things harder for the player
        {
            nextDifficultyIncreaseScore += 1000;
            //spawner.IncrementDifficultySpeed();
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            gems = GameObject.FindGameObjectsWithTag("Fuel");
            SetFuelGemSpeed(overdriveSpeed);
            SetObstacleSpeed(overdriveSpeed);
            IncrementOverdriveSpeed(1f);
            spawner.ShortenDelay(.50f);
        }
        if (fuelMeter <= 0f)
        {
            noFuel = true;
        }
        else if (fuelMeter >= 7)
        {
            fuelMeter--;
        }

        switch (overdrive)
        {
            case true:
                if (fuelMeter <= 5)
                {
                    overdrive = false;
                    spawner.overdriveActive = false;
                }
                obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                gems = GameObject.FindGameObjectsWithTag("Fuel");
                if (!upgradeDifficulty)

                {
                    SetFuelGemSpeed(overdriveSpeed);
                    SetObstacleSpeed(overdriveSpeed);
                    IncrementOverdriveSpeed(5.0f);
                    upgradeDifficulty = true;
                }

                spawner.ShortenDelay(.25f);
                break;
            case false:
                if (fuelMeter > 5)
                {
                    overdrive = true;
                    spawner.overdriveActive = true;

                    //GameObject.FindGameObjectsWithTag("Obstacle")[0].GetComponent<Obstacle>().SetSpeed(10);
                    //fuel_interval = 3.5f;
                }
                obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                gems = GameObject.FindGameObjectsWithTag("Fuel");
                //SetFuelGemSpeed(25f);
                //SetObstacleeSpeed(25f);
                break;
        }


        if (noFuel)
        {
            dm.ToggleDeathMenu();
        }
        else
        {
            if (overdrive) //in over drive mode
            {
                overdriveTimer += Time.deltaTime; //increase timer
                if (overdriveTimer >= overdriveLimit) //if timer reaches limit
                {
                    overdriveTimer = 0;
                    overdrive = false;
                    fuelMeter--;
                }
            }
            else if (!overdrive)
            {
                timer += Time.deltaTime;
                if (timer > fuel_interval)
                {
                    fuelMeter -= fuelLoss;
                    timer = 0;
                    upgradeDifficulty = false;
                }
            }

            fuelText.text = "fuel: " + fuelMeter.ToString();

        }
    } //end of update

    public void SetFuelGemSpeed(float speed)
    {
        foreach (GameObject gem in gems)
        {
            gem.GetComponent<FuelGem>().SetSpeed(speed);
        }
    }
    public void SetObstacleSpeed(float speed)
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().SetSpeed(speed);
        }
    }
    public void IncrementOverdriveSpeed(float increment)
    {
        overdriveSpeed += increment;
    }

    
    
}
