// Requires that Black Fade be present in scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScenesByNameButtonController : MonoBehaviour {
    private BlackFadeController BlackFadeControllerScript;
    public string SceneName;

    void Start() {
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
    }
    
    public void OnButtonClick() {
        BlackFadeControllerScript.FadeToScene(SceneName);
    }
}
