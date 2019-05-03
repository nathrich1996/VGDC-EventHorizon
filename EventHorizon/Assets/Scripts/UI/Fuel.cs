using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Text fuelText;
    public int fuelMeter;
    float timer;
    float fuel_interval;
    public DeathMenu dm;
    public Spawner spawner;
    public Score score;
    public bool noFuel = false;
    bool overdrive = false;

    float overdriveTimer = 0;
    MusicControl mControl;

    GameObject[] obstacles;
    GameObject[] gems;

    int nextDifficultyIncreaseScore = 1;

    // Start is called before the first frame update
    void Start()
    {
        fuelMeter = 5;
        timer = 0f;
        fuel_interval = 5.0f;
        mControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((score.score/1000) >= nextDifficultyIncreaseScore) //Make things harder for the player
        {
            nextDifficultyIncreaseScore += 1;
            spawner.IncrementDifficultySpeed();
            SetFuelGemSpeed();
            SetObstacleSpeed();
            spawner.Delay(.8f);
        }


        //Adjusts Fuel Levels
        if (noFuel)
        {
            dm.ToggleDeathMenu();
            mControl.DeathAudio();
        }
        else
        {
            if (overdrive) //in over drive mode
            {
                overdriveTimer += Time.deltaTime; //increase timer
                if (overdriveTimer > (fuel_interval*.75)) //if timer reaches limit
                {
                    overdriveTimer = 0;
                    DecrementFuel();
                }
            }
            else if (!overdrive)
            {
                timer += Time.deltaTime;
                if (timer > fuel_interval)
                {
                    DecrementFuel();
                    timer = 0;
                }
            }

            //fuelText.text = "fuel: " + fuelMeter.ToString();
            //fuelText.text = spawner.Debug();

        }
    }
    
    //Updates speed for all objects of specified type
    public void SetFuelGemSpeed()
    {
        gems = GameObject.FindGameObjectsWithTag("Fuel");
        foreach (GameObject gem in gems)
        {
            gem.GetComponent<FuelGem>().SetSpeed(spawner.GetSpeed());
        }
    }
    public void SetObstacleSpeed()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().SetSpeed(spawner.GetSpeed());
        }
    }

    //Increments Fuel, checks overdrive, updates object speeds if necessary
    public void IncrementFuel()
    {
        mControl.CollectFuel();
        if (fuelMeter < 10)
        {
            fuelMeter++;
        }
        if (fuelMeter > 5 && overdrive != true)
        {
            overdrive = true;
            mControl.OverdriveStart();
            SetFuelGemSpeed();
            SetObstacleSpeed();
            spawner.Delay(.5f);
        }
    }
    public void DecrementFuel()
    {
        fuelMeter--;
        if (fuelMeter < 1)
        {
            noFuel = true;
        }
        else if (fuelMeter <= 5 && overdrive != false)
        {
            overdrive = false;
            mControl.RunStart();
            SetFuelGemSpeed();
            SetObstacleSpeed();
            spawner.Delay(2f);
        }
    }

    public int GetFuelLevel()
    {
        return fuelMeter;
    }

    public bool OverdriveStatus()
    {
        return overdrive;
    }
  

    
    
}
