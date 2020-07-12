using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlChangePointController : MonoBehaviour {
    public KeyCode newLeftButton, newRightButton, newJumpButton;
    public KeyCodeScriptableObject currentLeftSO, currentRightSO, currentJumpSO;
    private bool hasPlayerEntered = false;

    private SpriteRenderer spriteRenderer;
    public Text uiText;

    public void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (hasPlayerEntered) return;
        if (other.gameObject.name != "Player") return;

        hasPlayerEntered = true;
        currentLeftSO.keyCode = newLeftButton;
        currentRightSO.keyCode = newRightButton;
        currentJumpSO.keyCode = newJumpButton;
        spriteRenderer.color = new Color(1, 1, 1, 0);
        uiText.color = new Color(1, 1, 1, 0);
    }
}
