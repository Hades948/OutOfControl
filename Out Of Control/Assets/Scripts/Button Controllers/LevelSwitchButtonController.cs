using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Controls whether each level button on the level select screen is active.
* TODO: Is this really a button controller as it doesn't provide a callback?  Rename?  Move?  etc.
*/
public class LevelSwitchButtonController : MonoBehaviour {
    private int LevelNumber;

    void Start() {
        // Figure out which level this button corresponds with.
        Text UIText = transform.GetChild(0).gameObject.GetComponent<Text>();
        LevelNumber = Int32.Parse(UIText.text.Substring(6));

        // Determine if this button should be active.
        GameManagerController GameManager = GameObject.Find("Game Manager").GetComponent<GameManagerController>();
        bool deactivate = LevelNumber > GameManager.LevelProgress;

        // Deactive if needed.
        if (deactivate) {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
