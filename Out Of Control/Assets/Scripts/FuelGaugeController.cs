using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Controls the Fuel slider on the Game UI.
*/
public class FuelGaugeController : MonoBehaviour {
    public BoundedFloatScriptableObject Fuel;
    private Slider slider;

    void Start() {
        slider = gameObject.GetComponent<Slider>();
        slider.minValue = Fuel.LowerBound;
        slider.maxValue = Fuel.UpperBound;
    }

    void Update() {
        slider.value = Fuel.GetValue();
    }
}
