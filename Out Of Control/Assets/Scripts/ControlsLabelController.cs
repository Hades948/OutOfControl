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
        string left = currentLeftKeyCode.keyCode.ToString();
        if (currentLeftKeyCode.keyCode == KeyCode.Alpha7) {
            left = "7";
        }
        uiText.text = "Left: "  + left  + "\n"
                    + "Right: " + currentRightKeyCode.keyCode + "\n"
                    + "Jump: "  + currentJumpKeyCode.keyCode;
    }
}
