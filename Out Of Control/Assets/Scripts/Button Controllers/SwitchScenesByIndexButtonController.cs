// Requires that Black Fade be present in scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Provides a callback for switching the scene by build index.
*/
public class SwitchScenesByIndexButtonController : MonoBehaviour {
    private BlackFadeController BlackFadeControllerScript;

    /**
    * Build index of the scene to switch to.
    */
    public int BuildIndex;

    void Start() {
        // Get handle on black fade for switching.
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
    }
    
    public void OnButtonClick() {
        BlackFadeControllerScript.FadeToScene(BuildIndex);
    }
}
