using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "ScriptableObjects/GameInfo")]
public class GameInfoScriptableObject : ScriptableObject {
    public bool isPaused = false;
}
