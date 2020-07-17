using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour {
    public GameEvent OnGamePauseEvent, OnGameUnpauseEvent;
    public GameInfoScriptableObject gameInfo;

    public void OnButtonClick() {
        if (gameInfo.isPaused) {
            OnGameUnpauseEvent.Raise();
            gameInfo.isPaused = false;
        } else {
            OnGamePauseEvent.Raise();
            gameInfo.isPaused = true;
        }
    }
}
