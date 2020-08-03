using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitchButtonController : MonoBehaviour {
    private int LevelNumber;

    void Start() {
        Text UIText = transform.GetChild(0).gameObject.GetComponent<Text>();
        LevelNumber = Int32.Parse(UIText.text.Substring(6));

        GameManagerController GameManager = GameObject.Find("Game Manager").GetComponent<GameManagerController>();
        bool deactivate = LevelNumber > GameManager.LevelProgress;
        if (deactivate) {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
