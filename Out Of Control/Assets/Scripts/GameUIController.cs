using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {
    private Canvas UICanvas;
    void Start() {
        UICanvas = gameObject.GetComponent<Canvas>();
    }

    public void OnGamePaused() {
        UICanvas.enabled = false;
    }

    public void OngameUnpaused() {
        UICanvas.enabled = true;
    }
}
