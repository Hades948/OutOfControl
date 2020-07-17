using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUIController : MonoBehaviour {
    Canvas canvas;
    void Start() {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void OnGamePaused() {
        canvas.enabled = true;
    }

    public void OngameUnpaused() {
        canvas.enabled = false;
    }
}
