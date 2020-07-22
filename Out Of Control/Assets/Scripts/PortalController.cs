using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour {
    private Text TextComponent;
    private BlackFadeController BlackFadeControllerScript;
    private bool IsPlayerInPortal;
    private long TimeOfEntry;
    
    void Start() {
        TextComponent = GameObject.Find("Portal Text").GetComponent<Text>();
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
        TextComponent.text = "";
    }

    void Update() {
        if (!IsPlayerInPortal) {
            TextComponent.text = "";
            return;
        }

        long elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - TimeOfEntry;
        if (elapsed < 1000) {
            TextComponent.text = "3";
        } else if (elapsed < 2000) {
            TextComponent.text = "2";
        } else if (elapsed < 3000) {
            TextComponent.text = "1";
        } else {
            BlackFadeControllerScript.FadeToNextScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") return;

        IsPlayerInPortal = true;
        TimeOfEntry = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name != "Player") return;

        IsPlayerInPortal = false;
    }
}
