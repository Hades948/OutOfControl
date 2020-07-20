using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "ScriptableObjects/Health")]
public class HealthScriptableObject : ScriptableObject {
    public int Value;
    public int InitialValue;
}
