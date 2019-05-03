using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSlider : MonoBehaviour
{
     Slider fuelBar;
    public Fuel fuel;
    

    // Start is called before the first frame update
    void Start()
    {
        fuelBar = GetComponent<Slider>();
        fuelBar.value = fuel.fuelMeter;
    }

    private void Update()
    {
        UpdateFuelBar();
    }
    // Update is called once per frame
    public void UpdateFuelBar()
    {
        fuelBar.value = fuel.GetFuelLevel();
    }
   
}
