using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUIController : MonoBehaviour {
    private Canvas UICanvas;

    void Start() {
        UICanvas = gameObject.GetComponent<Canvas>();
        UICanvas.enabled = false;
    }

    public void OnGamePaused() {
        UICanvas.enabled = true;
    }

    public void OnGameUnpaused() {
        UICanvas.enabled = false;
    }
}
