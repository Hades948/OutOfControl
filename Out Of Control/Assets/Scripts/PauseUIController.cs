using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUIController : MonoBehaviour {
    private Canvas canvas;

    void Start() {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void OnGamePaused() {
        canvas.enabled = true;
    }

    public void OnGameUnpaused() {
        canvas.enabled = false;
    }
}
