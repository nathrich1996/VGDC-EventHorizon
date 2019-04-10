using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score_text;

    private int score;
    private int multiplier;
    private float timer;
    private float score_interval = 0.20f;
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
        timer += Time.deltaTime;
        if (timer > score_interval) //add score by 10 every three seconds
        {
            score += multiplier;
            score_text.text = "score: " + score.ToString();
            timer = 0;
        }
    }
    
}
