using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StateController stateController;
    public PlayerController playerController;
    public UIController uiController;
    public GameObject enemiesParent;
    

    void Start()
    {
        stateController.ChangeGameState(stateController.GetPlayingState());
        print(stateController.GetCurrentGameState());
    }

    
    void Update()
    {
        
    }

    public void GameWin() {
        stateController.ChangeGameState(stateController.GetGameWinState());
        uiController.ShowGameWin();
        playerController.ResetPosition();
        playerController.FreezePlayer();
        foreach (Transform child in enemiesParent.transform) {

            child.GetComponent<Enemy>().FreezeEnemy();
            child.GetComponent<Enemy>().ResetPosition();
        }
    }

    public void GameOver() {
        stateController.ChangeGameState(stateController.GetGameOverState());
        uiController.ShowGameOver();
        playerController.ResetPosition();
        playerController.FreezePlayer();
        foreach (Transform child in enemiesParent.transform) {
            child.GetComponent<Enemy>().FreezeEnemy();
            child.GetComponent<Enemy>().ResetPosition();
        }
    }


    public void ResetAllPositions() {
        playerController.ResetPosition();
        foreach (Transform child in enemiesParent.transform) {
            child.GetComponent<Enemy>().ResetPosition();
        }
    }
}
