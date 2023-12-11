using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    #region Variables
    
    public enum GameState
    {
        Menu,
        Playing,
        Reverse,
        Paused,
        GameOver
    }

    private GameState _gameState;

    #endregion

    #region State Machine

    public void ChangeGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Menu:
                OnMenuState();
                break;
            case GameState.Playing:
                OnPlayingState();
                break;
            case GameState.Reverse:
                OnReverseState();
                break;
            case GameState.Paused:
                OnPausedState();
                break;
            case GameState.GameOver:
                OnGameOverState();
                break;
        }
    }

    #endregion

    #region State Change Methods

    private void OnMenuState()
    {
        _gameState = GameState.Menu;
    }

    private void OnPlayingState()
    {
        _gameState = GameState.Playing;
    }

    private void OnReverseState()
    {
        _gameState = GameState.Reverse;
    }

    private void OnPausedState()
    {
        _gameState = GameState.Paused;
    }

    private void OnGameOverState()
    {
        _gameState = GameState.GameOver;
    }

    #endregion

    #region Getters and Setters

    public GameState GetGameState()
    {
        return _gameState;
    }

    public GameState GetMenuState(){return GameState.Menu;}
    public GameState GetPlayingState(){return GameState.Playing;}
    public GameState GetReverseState(){return GameState.Reverse;}
    public GameState GetPausedState(){return GameState.Paused;}
    public GameState GetGameOverState(){return GameState.GameOver;}


    #endregion


}
