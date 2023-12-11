using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text livesText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score) {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lives) {
        livesText.text = "Lives: " + lives;
    }


    
}
