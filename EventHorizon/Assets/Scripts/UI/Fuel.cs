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
    public bool noFuel = false;
    // Start is called before the first frame update
    void Start()
    {
        fuelMeter = 5;
        timer = 0f;
        fuelLoss = 1;
        fuel_interval = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelMeter <= 0f)
        {
            noFuel = true;
        }
        else if (fuelMeter >= 7)
        {
            fuelMeter--;
        }
        if (noFuel)
        {
            dm.ToggleDeathMenu();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > fuel_interval)
            {
                fuelMeter -= fuelLoss;
                timer = 0;
            }
            fuelText.text = "fuel: " + fuelMeter.ToString();

        }
    }
}
