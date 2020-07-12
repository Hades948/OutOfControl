using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const float DEADZONE = 0.1f;
    public float jumpPower;
    public float speed;
    public HealthScriptableObject health;
    public KeyCodeScriptableObject currentLeftKeyCode, currentRightKeyCode, currentJumpKeyCode;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Collider2D playerFeetCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite hurtSprite;
    private Animator animator;
    private GameObject platforms;
    private GameObject enemies;
    private Vector3 initialPosition;

    private long timeOfEnemyCollision = -1;
    private bool isHurt = false;

    private const int LEFT = -1, IDLE = 0, RIGHT = 1;

    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerFeetCollider = GameObject.Find("Player Feet Collider").gameObject.GetComponent<BoxCollider2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        platforms = GameObject.Find("Platforms");
        enemies = GameObject.Find("Enemies");

        initialPosition = transform.position;

        // Set up SOs
        health.value = health.initialValue;
        currentLeftKeyCode.keyCode = currentLeftKeyCode.initialKeyCode;
        currentRightKeyCode.keyCode = currentRightKeyCode.initialKeyCode;
        currentJumpKeyCode.keyCode = currentJumpKeyCode.initialKeyCode;
    }

    void FixedUpdate() {
        // Horizontal movement
        if (Input.GetKey(currentRightKeyCode.keyCode)) {
            // Move right.
            rigidBody.AddForce(transform.right * speed, ForceMode2D.Impulse);
            animator.SetInteger("direction", RIGHT);
        } else if (Input.GetKey(currentLeftKeyCode.keyCode)) {
            // Move left.
            rigidBody.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            animator.SetInteger("direction", LEFT);
        } else {
            animator.SetInteger("direction", IDLE);
        }

        bool inAir = true;
        foreach (Transform t1 in platforms.transform) {
            foreach (Transform t2 in t1) {//add comments
                if (t2.gameObject.name == "Ground Collider" && playerFeetCollider.IsTouching(t2.gameObject.GetComponent<Collider2D>())) {
                    inAir = false;
                    break;
                }
            }
        }

        // Jumping movement
        if (Input.GetKey(currentJumpKeyCode.keyCode) && !inAir) {
            rigidBody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
        animator.SetBool("inAir", inAir);

        // Check enemy collisions
        if (!isHurt) {
            // TODO: This could be done with callbacks a bit nicer.  Not needed for jam, but better practice.
            foreach (Transform t in enemies.transform) {
                if (playerCollider.IsTouching(t.gameObject.GetComponent<Collider2D>())) {
                    health.value--;
                    timeOfEnemyCollision = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    isHurt = true;
                    rigidBody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
                    animator.enabled = false;
                    spriteRenderer.sprite = hurtSprite;
                    break;
                }
            }
        } else {
            long elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - timeOfEnemyCollision;
            if (elapsed % 400 < 200) {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            } else {
                spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1);
            }
            if (elapsed >= 2000) {
                isHurt = false;
                animator.enabled = true;
            }
        }
        
        // Check for death
        if (health.value <= 0 || transform.position.y < -25.0f) {
            transform.position = initialPosition;
            health.value = health.initialValue;
            rigidBody.velocity = Vector2.zero;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            isHurt = false;
        }
    }
}
