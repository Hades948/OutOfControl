using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {
    Canvas canvas;
    void Start() {
        canvas = gameObject.GetComponent<Canvas>();
    }

    public void OnGamePaused() {
        canvas.enabled = false;
    }

    public void OngameUnpaused() {
        canvas.enabled = true;
    }
}
