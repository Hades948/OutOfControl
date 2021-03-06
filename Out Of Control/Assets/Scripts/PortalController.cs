﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
* Controls the portals at the end of the level.
*/
public class PortalController : MonoBehaviour {
    private GameManagerController GameManager;
    private Text TextComponent;
    private BlackFadeController BlackFadeControllerScript;

    private bool IsPlayerInPortal;
    private long TimeOfEntry;
    private int LevelNumber;
    
    void Start() {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManagerController>();
        TextComponent = GameObject.Find("Portal Text").GetComponent<Text>();
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
        TextComponent.text = "";

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != "Test Environment Level") {
            LevelNumber = Int32.Parse(sceneName.Substring(6));
        }
    }

    void Update() {
        // If player is not in the portal, set text to empty and do nothing else.
        if (!IsPlayerInPortal) {
            TextComponent.text = "";
            return;
        }

        // Count down when player is in the portal.
        long elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - TimeOfEntry;
        if (elapsed < 1000) {
            TextComponent.text = "3";
        } else if (elapsed < 2000) {
            TextComponent.text = "2";
        } else if (elapsed < 3000) {
            TextComponent.text = "1";
        } else {
            // If enough time has elapsed, fade to next scene.
            BlackFadeControllerScript.FadeToNextScene();
            if (GameManager.LevelProgress <= LevelNumber) {
                GameManager.LevelProgress = LevelNumber + 1;
            }
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
