using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerController : MonoBehaviour {
    public GameManagerScriptableObject GameManager;

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            GameManager.ToggleIsPaused();
        }
    }
}
