using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldImage : MonoBehaviour
{
    Image shieldImage;
    public Sprite fullShield;
    public Sprite halfShield;
    public Sprite lowShield;
    public Shields shield;
    // Start is called before the first frame update
    void Start()
    {
        shieldImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (shield.currentShields)
        {
            case 3:
                shieldImage.sprite = fullShield;
                break;
            case 2:
                shieldImage.sprite = halfShield;
                break;
            case 1:
                shieldImage.sprite = lowShield;
                break;
        }

    }
}
