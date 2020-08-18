using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Contains info about the game state and event architecture for pausing.
* TODO: Move this to Game Manager Controller?
*/
[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager")]
public class GameManagerScriptableObject : ScriptableObject {
    public GameEvent OnGamePauseEvent, OnGameUnpauseEvent;
    private bool IsPaused = false;

    public void ToggleIsPaused() {
        if (IsPaused) {
            OnGameUnpauseEvent.Raise();
            IsPaused = false;
        } else {
            OnGamePauseEvent.Raise();
            IsPaused = true;
        }
    }
}
