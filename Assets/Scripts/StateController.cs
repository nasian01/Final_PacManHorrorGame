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
        GameOver,
        GameWin
    }

    public UIController uiController;

    private GameState _gameState;
    private static StateController _instance;

    [SerializeField] private List<Enemy> _observers = new List<Enemy>();

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
            case GameState.GameWin:
                OnGameWinState();
                break;
        }
    }

    #endregion

    #region State Change Methods

    private void OnMenuState()
    {
        _gameState = GameState.Menu;
    }

    public void OnPlayingState()
    {
        print("Playing State");
        _gameState = GameState.Playing;
        NotifyEnemies(GameState.Playing);
    }

    private void OnReverseState()
    {
        print("Reverse State");
        _gameState = GameState.Reverse;
        NotifyEnemies(GameState.Reverse);
    }

    private void OnPausedState()
    {
        _gameState = GameState.Paused;
    }

    private void OnGameOverState()
    {
        _gameState = GameState.GameOver;
    }

    private void OnGameWinState()
    {
        _gameState = GameState.GameWin;
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
                    enemy.SetReverse(false);
                }
                break;
            case GameState.Reverse:
                foreach (Enemy enemy in _observers)
                {
                    enemy.SetReverse(true);
                }
                StartCoroutine(EnemyTimer());
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
        }
    }

    IEnumerator EnemyTimer() {
        yield return new WaitForSeconds(6f);
        foreach (Enemy enemy in _observers)
        {
            enemy.SetReverse(false);
        }
        ChangeGameState(GameState.Playing);
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
    public GameState GetGameWinState(){return GameState.GameWin;}

    #endregion


}
