using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoundedFloat", menuName = "ScriptableObjects/BoundedFloat")]
public class BoundedFloatScriptableObject : ScriptableObject {
    public float LowerBound;
    public float UpperBound;
    private float _value;

    public float GetValue() {
        return _value;
    }

    public void SetValue(float value) {
        _value = Mathf.Clamp(value, LowerBound, UpperBound);
    }

    public void ChangeValue(float change) {
        SetValue(_value + change);
    }
}
