using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour {
    public GameInfoScriptableObject gameInfo;

    public void OnButtonClick() {
        gameInfo.isPaused = true;//TODO This could probably be done with an event system instead.  I want to explore that route before proceeding.
    }
}
