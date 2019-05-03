using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shields : MonoBehaviour
{
    public Text shields;
    public int currentShields;
    public DeathMenu dm;

    MusicControl mControl;

   public  bool noShields = false;
    // Start is called before the first frame update
    void Start()
    {
        currentShields = 3;
        mControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentShields <= 0)
        {
            currentShields = 0;
            noShields = true;
        }
        if (noShields)
        {
            dm.ToggleDeathMenu();
        }
        //shields.text = "shield: " + currentShields.ToString();
    }
}
