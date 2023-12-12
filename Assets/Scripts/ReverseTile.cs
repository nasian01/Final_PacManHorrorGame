using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTile : MonoBehaviour
{
    public StateController stateController;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            stateController.ChangeGameState(stateController.GetReverseState());
            Destroy(gameObject);
        }
    }
}
