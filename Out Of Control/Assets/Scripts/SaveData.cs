using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* A serializable class which contains all game data to store between sessions.
*/
[System.Serializable]
public class SaveData {
    /**
    * The furthest level that the player has made it to.
    */
    public int LevelProgress;
}
