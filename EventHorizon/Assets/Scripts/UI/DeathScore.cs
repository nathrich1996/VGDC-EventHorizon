using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScore : MonoBehaviour
{
    public Text score_text;
    public Score sc;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score < sc.score)
            if (sc.score > 4000) //count faster if it is really high
                score += 50;
            else if (sc.score <= 4000 && sc.score > 2000) ///count a little fast
                score += 20;
            else if (sc.score < 2000) 
                score +=10;
        else
            score = sc.score;
        score_text.text = "Score: " + score.ToString();
    }
}
