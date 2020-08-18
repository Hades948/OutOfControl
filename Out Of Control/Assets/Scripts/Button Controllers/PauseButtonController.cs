using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Provides a callback for when the game is paused.
*/
public class PauseButtonController : MonoBehaviour {
    public GameManagerScriptableObject GameManager;

    public void OnButtonClick() {
        GameManager.ToggleIsPaused();
    }
}
