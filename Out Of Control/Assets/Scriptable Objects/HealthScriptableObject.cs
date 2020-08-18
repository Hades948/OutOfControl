using UnityEngine;

/**
* Contains a value for the player's health.
* TODO: Replace with just an int SO (or move to game manager?).
*/
[CreateAssetMenu(fileName = "Health", menuName = "ScriptableObjects/Health")]
public class HealthScriptableObject : ScriptableObject {
    public int Value;
    public int InitialValue;
}
