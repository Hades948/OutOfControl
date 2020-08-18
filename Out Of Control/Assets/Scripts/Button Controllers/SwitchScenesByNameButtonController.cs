// Requires that Black Fade be present in scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Provides a callback for switching the scene by scene name.
*/
public class SwitchScenesByNameButtonController : MonoBehaviour {
    private BlackFadeController BlackFadeControllerScript;

    /**
    * Scene name of the scene to switch to.
    */
    public string SceneName;

    void Start() {
        // Get handle on black fade for switching.
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
    }
    
    public void OnButtonClick() {
        BlackFadeControllerScript.FadeToScene(SceneName);
    }
}
