using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text gameResult;
    public CanvasGroup gameResultCanvasGroup;

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

    public void ShowGameWin() {
        gameResult.text = "You Win!";
        ShowCanvasGroup(gameResultCanvasGroup);
    }

    public void HideGameWin() {
        HideCanvasGroup(gameResultCanvasGroup);
    }

    public void ShowGameOver() {
        gameResult.text = "Game Over";
        ShowCanvasGroup(gameResultCanvasGroup);
    }

    public void HideGameOver() {
        HideCanvasGroup(gameResultCanvasGroup);
    }


    private void ShowCanvasGroup(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    private void HideCanvasGroup(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    
}
