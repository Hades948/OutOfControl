using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsLabelController : MonoBehaviour {
    public KeyCodeScriptableObject currentLeftKeyCode, currentRightKeyCode, currentJumpKeyCode;
    private Text uiText;

    void Start() {
        uiText = gameObject.GetComponent<Text>();
    }
    void Update() {
        uiText.text = "Left: "  + currentLeftKeyCode.keyCode  + "\n"
                    + "Right: " + currentRightKeyCode.keyCode + "\n"
                    + "Jump: "  + currentJumpKeyCode.keyCode;
    }
}
