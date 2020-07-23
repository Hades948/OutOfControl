// Requires that Black Fade be present in scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScenesByIndexButtonController : MonoBehaviour {
    private BlackFadeController BlackFadeControllerScript;
    public int BuildIndex;

    void Start() {
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
    }
    
    public void OnButtonClick() {
        BlackFadeControllerScript.FadeToScene(BuildIndex);
    }
}
