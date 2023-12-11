using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StateController stateController;
    public PlayerController playerController;
    public UIController uiController;
    

    void Start()
    {
        stateController.ChangeGameState(stateController.GetPlayingState());
        print(stateController.GetCurrentGameState());
    }

    
    void Update()
    {
        
    }

    public void GameOver() {
        stateController.ChangeGameState(stateController.GetGameOverState());
    }
}
