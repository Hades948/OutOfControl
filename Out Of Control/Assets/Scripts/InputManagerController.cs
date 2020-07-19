using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerController : MonoBehaviour {
    public GameManagerScriptableObject gameManager;

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            gameManager.toggleIsPaused();
        }
    }
}
