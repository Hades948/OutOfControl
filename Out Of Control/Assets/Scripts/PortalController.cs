using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour {
    public Text uiText;
    private BlackFadeController blackFadeController;
    private bool isPlayerInPortal;
    private long timeOfEntry;
    
    public void Start() {
        uiText = GameObject.Find("Portal Text").GetComponent<Text>();
        blackFadeController = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
        uiText.text = "";
    }

    public void Update() {
        if (!isPlayerInPortal) {
            uiText.text = "";
            return;
        }

        long elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - timeOfEntry;
        if (elapsed < 1000) {
            uiText.text = "3";
        } else if (elapsed < 2000) {
            uiText.text = "2";
        } else if (elapsed < 3000) {
            uiText.text = "1";
        } else {
            blackFadeController.FadeToNextScene();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") return;

        isPlayerInPortal = true;
        timeOfEntry = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name != "Player") return;

        isPlayerInPortal = false;
    }
}
