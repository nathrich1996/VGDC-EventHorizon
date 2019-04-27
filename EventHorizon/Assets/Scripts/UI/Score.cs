using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score_text;

    public int score;
    private int multiplier;
    private float timer;
    private float score_interval = 0.20f;
    public Fuel fuel;
    public DeathMenu dm; 
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        multiplier = 10;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverdrive();
        timer += Time.deltaTime;
        if (!dm.deathScreenActive)
        {
            if (timer > score_interval) //add score by 10 every three seconds
            {
                score += multiplier;
                score_text.text = score.ToString();
                timer = 0;
            }
        }
        
    }
    void CheckOverdrive()

    {
        if (fuel.overdrive)
        {
            score_text.color = Color.yellow;
            multiplier = 20;
        }
        else
        {
            score_text.color = Color.white;
            multiplier = 10;
        }
    }


}
