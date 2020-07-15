using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLabelController : MonoBehaviour {
    public KeyCodeScriptableObject currentKeyCode;
    private Text uiText;

    void Start() {
        uiText = gameObject.GetComponent<Text>();
    }
    void Update() {
        // Change "Alpha7" to "7"
        string label = currentKeyCode.keyCode.ToString();
        if (currentKeyCode.keyCode == KeyCode.Alpha7) {
            label = "7";
        }

        uiText.text = label;
    }
}
