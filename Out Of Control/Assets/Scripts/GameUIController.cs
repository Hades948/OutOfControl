using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Controls in-game UI.
*/
public class GameUIController : MonoBehaviour {
    private Canvas UICanvas;
    void Start() {
        UICanvas = gameObject.GetComponent<Canvas>();
    }

    public void OnGamePaused() {
        // Hide UI when paused.
        UICanvas.enabled = false;
    }

    public void OngameUnpaused() {
        // Show UI when unpaused.
        UICanvas.enabled = true;
    }
}
