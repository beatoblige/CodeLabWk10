using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    public int score;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreHit(int scoreIncrease)   
    {
        score = score + scoreIncrease;
        scoreText.text = score.ToString();
    }
}

