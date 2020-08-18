using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Manages misc. input for the game.
*/
public class InputManagerController : MonoBehaviour {
    public GameManagerScriptableObject GameManager;

    void Update() {
        // Pause on escape pressed.
        if (Input.GetKeyUp(KeyCode.Escape)) {
            GameManager.ToggleIsPaused();
        }
    }
}
