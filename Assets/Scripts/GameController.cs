using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StateController stateController;

    void Start()
    {
        stateController.ChangeGameState(stateController.GetMenuState());
    }

    
    void Update()
    {
        
    }
}
