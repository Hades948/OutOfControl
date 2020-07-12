using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLabelController : MonoBehaviour {
    public HealthScriptableObject health;
    private Text uiText;

    void Start() {
        uiText = gameObject.GetComponent<Text>();
    }
    void Update() {
        uiText.text = "Health: " + health.value;
    }
}
