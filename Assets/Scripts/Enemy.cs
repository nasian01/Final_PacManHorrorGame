using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Enemy : MonoBehaviour
{
    private Grid _grid;
    private PlayerController _playerController;
    private StateController _stateController;
    void Start()
    {
        _stateController = StateController.Instance;
        _stateController.AddObserver(this);
        _grid = GameObject.Find("Grid").GetComponent<Grid>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        
    }

    // public void UpdateState()
    // {
    //     if (_stateController.GetCurrentGameState() == _stateController.GameState.Playing)
    //     {
    //         Vector3Int playerPos = _grid.WorldToCell(_playerController.transform.position);
    //         Vector3Int enemyPos = _grid.WorldToCell(transform.position);
    //         Vector3Int nextPos = Vector3Int.zero;
    //         if (playerPos.x > enemyPos.x)
    //         {
    //             nextPos = enemyPos + Vector3Int.right;
    //         }
    //         else if (playerPos.x < enemyPos.x)
    //         {
    //             nextPos = enemyPos + Vector3Int.left;
    //         }
    //         else if (playerPos.y > enemyPos.y)
    //         {
    //             nextPos = enemyPos + Vector3Int.up;
    //         }
    //         else if (playerPos.y < enemyPos.y)
    //         {
    //             nextPos = enemyPos + Vector3Int.down;
    //         }
    //         if (_grid.GetTile(nextPos) != null)
    //         {
    //             transform.position = _grid.GetCellCenterWorld(nextPos);
    //         }
    //     }
    // }


}
