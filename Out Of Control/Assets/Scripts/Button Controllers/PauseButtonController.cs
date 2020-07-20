using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour {
    public GameManagerScriptableObject GameManager;

    public void OnButtonClick() {
        GameManager.ToggleIsPaused();
    }
}
