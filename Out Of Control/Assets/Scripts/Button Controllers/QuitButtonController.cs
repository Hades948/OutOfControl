using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Provides a callback for closing the game.
*/
public class QuitButtonController : MonoBehaviour {
    public void OnButtonPress() {
        Application.Quit();
    }
}
