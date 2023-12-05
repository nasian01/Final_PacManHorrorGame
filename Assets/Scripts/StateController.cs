using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    #region Variables

    //singleton pattern
    public static StateController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StateController>();
                if (_instance == null)
                {
                    Debug.LogError("StateController instance not found");
                }
            }
            return _instance;
        }
    }
    
    //state pattern
    public enum GameState
    {
        Menu,
        Playing,
        Reverse,
        Paused,
        GameOver
    }

    private GameState _gameState;
    private static StateController _instance;

    private List<Enemy> _observers = new List<Enemy>();

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
        NotifyEnemies(GameState.Playing);
    }

    private void OnReverseState()
    {
        _gameState = GameState.Reverse;
        foreach (Enemy enemy in _observers)
        {
            // enter reversed state
        }
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

    #region Observer Pattern
    public void AddObserver(Enemy observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(Enemy observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyEnemies(GameState state)
    {
        switch(state)
        {
            case GameState.Menu:
                break;
            case GameState.Playing:
                foreach (Enemy enemy in _observers)
                {
                    //enemy.UpdateState();
                }
                break;
            case GameState.Reverse:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
        }
    }

    #endregion

    #region Getters and Setters

    public GameState GetCurrentGameState()
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
