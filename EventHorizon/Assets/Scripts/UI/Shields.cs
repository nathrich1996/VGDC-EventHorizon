using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shields : MonoBehaviour
{
    public Text shields;
    private int currentShields;
    // Start is called before the first frame update
    void Start()
    {
        currentShields = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        shields.text = "shield: " + currentShields.ToString();
    }
}
