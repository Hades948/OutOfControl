using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUIController : MonoBehaviour {
    public BoundedFloatScriptableObject FuelLevel;

    private Text TextComponent;

    void Start() {
        TextComponent = gameObject.GetComponent<Text>();
    }

    void Update() {
        // TODO: Replace w/ events
        TextComponent.text = "Fuel: " + FuelLevel.GetValue();
    }
}
