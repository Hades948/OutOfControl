using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const float DEADZONE = 0.1f;
    public float jumpPower;
    public float speed;
    public AudioClip oofClip, boingClip;
    public HealthScriptableObject health;
    public KeyCodeScriptableObject currentLeftKeyCode, currentRightKeyCode, currentJumpKeyCode;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Collider2D playerFeetCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite hurtSprite;
    private Animator animator;
    private AudioSource audioSource;
    private GameObject platforms;
    private GameObject enemies;
    private Vector3 initialPosition;
    private Vector2 prePauseVelocity;

    private long timeOfEnemyCollision = -1;
    private bool isHurt = false;

    private const int LEFT = -1, IDLE = 0, RIGHT = 1;

    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerFeetCollider = GameObject.Find("Player Feet Collider").gameObject.GetComponent<BoxCollider2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        platforms = GameObject.Find("Platforms");
        enemies = GameObject.Find("Enemies");

        initialPosition = transform.position;

        // Set up SOs
        health.Value = health.InitialValue;
        currentLeftKeyCode.CurrentKeyCode = currentLeftKeyCode.InitialKeyCode;
        currentRightKeyCode.CurrentKeyCode = currentRightKeyCode.InitialKeyCode;
        currentJumpKeyCode.CurrentKeyCode = currentJumpKeyCode.InitialKeyCode;
    }

    void FixedUpdate() {
        // Horizontal movement
        if (Input.GetKey(currentRightKeyCode.CurrentKeyCode)) {
            // Move right.
            rigidBody.AddForce(transform.right * speed, ForceMode2D.Impulse);
            animator.SetInteger("direction", RIGHT);
        } else if (Input.GetKey(currentLeftKeyCode.CurrentKeyCode)) {
            // Move left.
            rigidBody.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            animator.SetInteger("direction", LEFT);
        } else {
            animator.SetInteger("direction", IDLE);
        }

        // Test if in air
        bool inAir = true;
        foreach (Transform t1 in platforms.transform) { // Iterate over platforms
            foreach (Transform t2 in t1) { // Find ground collider within each platform
                if (t2.gameObject.name == "Ground Collider" && playerFeetCollider.IsTouching(t2.gameObject.GetComponent<Collider2D>())) {
                    inAir = false;
                    break;
                }
            }
        }

        // Jumping movement
        if (Input.GetKey(currentJumpKeyCode.CurrentKeyCode) && !inAir) {
            rigidBody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            audioSource.clip = boingClip;
            audioSource.Play();
        }
        animator.SetBool("inAir", inAir);

        // Check enemy collisions
        if (!isHurt) {
            // TODO: This could be done with callbacks a bit nicer.  Not needed for jam, but better practice.
            foreach (Transform t1 in enemies.transform) {
                foreach (Transform t2 in t1) {
                    if (playerCollider.IsTouching(t2.gameObject.GetComponent<Collider2D>())) {
                        health.Value--;
                        timeOfEnemyCollision = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        isHurt = true;
                        rigidBody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
                        animator.enabled = false;
                        spriteRenderer.sprite = hurtSprite;
                        audioSource.clip = oofClip;
                        audioSource.Play();
                        break;
                    }
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
        
        // Check for death and respawn
        if (transform.position.y < -25.0f) {
            audioSource.clip = oofClip;
            audioSource.Play();
        }
        if (health.Value <= 0 || transform.position.y < -25.0f) {
            transform.position = initialPosition;
            health.Value = health.InitialValue;
            rigidBody.velocity = Vector2.zero;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            isHurt = false;
            animator.enabled = true;

            // Respawn Fly men
            foreach (Transform t1 in enemies.transform) {
                if (t1.gameObject.name != "Fly Men") continue;

                foreach (Transform t2 in t1) {
                    t2.gameObject.GetComponent<FlyManController>().respawn();
                }

                break;
            }
        }
    }

    public void OnGamePause() {
        prePauseVelocity = rigidBody.velocity;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.enabled = false;
    }

    public void OnGameUnpause() {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidBody.velocity = prePauseVelocity;
        animator.enabled = true;
    }
}
