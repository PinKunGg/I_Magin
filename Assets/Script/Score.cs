using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text ScoreText;

    int scorePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + scorePoint;
    }

    public void scoreCount(int Point)
    {
        scorePoint = scorePoint + Point;
    }
}
