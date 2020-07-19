using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour {
    public GameManagerScriptableObject gameManager;

    public void OnButtonClick() {
        gameManager.toggleIsPaused();
    }
}
