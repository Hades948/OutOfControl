using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager")]
public class GameManagerScriptableObject : ScriptableObject {
    public GameEvent OnGamePauseEvent, OnGameUnpauseEvent;
    public bool isPaused = false;

    public void toggleIsPaused() {
        if (isPaused) {
            OnGameUnpauseEvent.Raise();
            isPaused = false;
        } else {
            OnGamePauseEvent.Raise();
            isPaused = true;
        }
    }
}
