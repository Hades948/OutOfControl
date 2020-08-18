using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Controls UI Component for displaying the fuel.
* Note: This is just temporary.  Eventually, it will be replaced with some kind of gauge.
*/
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
