using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Controls pause UI.
*/
public class PauseUIController : MonoBehaviour {
    private Canvas UICanvas;

    void Start() {
        UICanvas = gameObject.GetComponent<Canvas>();
        UICanvas.enabled = false;
    }

    public void OnGamePaused() {
        // Show UI when paused.
        UICanvas.enabled = true;
    }

    public void OnGameUnpaused() {
        // Hide UI when unpaused.
        UICanvas.enabled = false;
    }
}
