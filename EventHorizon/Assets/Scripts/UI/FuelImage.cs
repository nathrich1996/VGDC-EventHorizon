using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelImage : MonoBehaviour
{
    Image gemImage;
    public Sprite lowfuel;
    public Sprite halfFuel;
    public Sprite fullFuel;
    public Sprite overdriveFuel;

    public Fuel fuel;
    // Start is called before the first frame update
    void Start()
    {
        gemImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int fuelM = fuel.GetFuelLevel();
        if (fuelM == 1)
        {
            gemImage.sprite = lowfuel;
        }
        if (fuelM == 3)
        {
            gemImage.sprite = halfFuel;
        }
        if (fuelM == 5)
        {
            gemImage.sprite = fullFuel;
        }
        if (fuelM > 5)
        {
            gemImage.sprite = overdriveFuel;
        }
    }
}
