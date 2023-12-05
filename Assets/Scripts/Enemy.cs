using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Grid _grid;
    private PlayerController _playerController;
    private StateController _stateController;
    void Start()
    {
        _stateController = StateController.Instance;
        _stateController.AddObserver(this);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        
    }

    public void UpdateState(StateController stateController) {
        if (stateController.GetGameState() == StateController.GetPlayingState()) {
            _grid = GameObject.Find("Grid").GetComponent<Grid>();
            Vector3Int playerPos = _grid.WorldToCell(_playerController.transform.position);
            Vector3Int enemyPos = _grid.WorldToCell(transform.position);
            Vector3Int nextPos = Vector3Int.zero;
            if (Mathf.Abs(playerPos.x - enemyPos.x) > Mathf.Abs(playerPos.y - enemyPos.y)) {
                if (playerPos.x > enemyPos.x) {
                    nextPos = enemyPos + Vector3Int.right;
                } else {
                    nextPos = enemyPos + Vector3Int.left;
                }
            } else {
                if (playerPos.y > enemyPos.y) {
                    nextPos = enemyPos + Vector3Int.up;
                } else {
                    nextPos = enemyPos + Vector3Int.down;
                }
            }
            if (_grid.GetTile(nextPos) == null) {
                transform.position = _grid.CellToWorld(nextPos);
            }
        }
    }


}
