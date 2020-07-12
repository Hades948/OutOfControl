using UnityEngine;

[CreateAssetMenu(fileName = "KeyCode", menuName = "ScriptableObjects/KeyCode")]
public class KeyCodeScriptableObject : ScriptableObject {
    public KeyCode keyCode;
    public KeyCode initialKeyCode;
}
