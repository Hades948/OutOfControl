using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLabelController : MonoBehaviour {
    public KeyCodeScriptableObject BoundKeyCode;
    private Text TextComponent;

    void Start() {
        TextComponent = gameObject.GetComponent<Text>();
    }
    void Update() {
        // Change "Alpha7" to "7"
        string label = BoundKeyCode.CurrentKeyCode.ToString();
        if (BoundKeyCode.CurrentKeyCode == KeyCode.Alpha7) {
            label = "7";
        }

        TextComponent.text = label;
    }
}
