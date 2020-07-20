using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlChangePointController : MonoBehaviour {
    public KeyCode NewLeftButton, NewRightButton, NewJumpButton;
    public KeyCodeScriptableObject LeftKeyCode, RightKeyCode, JumpKeyCode;
    private bool HasPlayerEntered = false;

    private SpriteRenderer SpriteRendererComponent;
    public Text TextComponent;

    public void Start() {
        SpriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (HasPlayerEntered) return;
        if (other.gameObject.name != "Player") return;

        HasPlayerEntered = true;
        LeftKeyCode.CurrentKeyCode = NewLeftButton;
        RightKeyCode.CurrentKeyCode = NewRightButton;
        JumpKeyCode.CurrentKeyCode = NewJumpButton;
        SpriteRendererComponent.color = new Color(1, 1, 1, 0);
        TextComponent.color = new Color(1, 1, 1, 0);
    }
}
