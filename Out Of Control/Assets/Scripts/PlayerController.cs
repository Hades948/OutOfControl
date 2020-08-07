using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float JumpPower;
    public float Speed;
    public AudioClip HurtClip, JumpClip;
    public HealthScriptableObject Health;
    public BoundedFloatScriptableObject FuelLevel;
    public Sprite HurtSprite;

    private Rigidbody2D RigidbodyComponent;
    private Collider2D PlayerCollider;
    private Collider2D PlayerFeetCollider;
    private SpriteRenderer SpriteRendererComponent;
    private Animator AnimatorComponent;
    private AudioSource AudioClipSource;
    private GameObject Platforms;
    private GameObject Enemies;
    private Vector3 InitialPosition;
    private Vector2 PrePauseVelocity;

    private long TimeOfEnemyCollision = -1;
    private bool IsHurt = false;
    private float FuelDepletionRate = 150.0f;

    private const float DEADZONE = 0.1f;
    private const float MAX_SPEED = 20.0f;
    private const int LEFT = -1, IDLE = 0, RIGHT = 1;

    void Start() {
        RigidbodyComponent = gameObject.GetComponent<Rigidbody2D>();
        PlayerFeetCollider = GameObject.Find("Player Feet Collider").gameObject.GetComponent<BoxCollider2D>();
        PlayerCollider = gameObject.GetComponent<BoxCollider2D>();
        SpriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
        AnimatorComponent = gameObject.GetComponent<Animator>();
        AudioClipSource = gameObject.GetComponent<AudioSource>();
        Platforms = GameObject.Find("Platforms");
        Enemies = GameObject.Find("Enemies");

        InitialPosition = transform.position;

        // Set up SOs
        Health.Value = Health.InitialValue;
        FuelLevel.SetValue(FuelLevel.UpperBound);
    }

    void FixedUpdate() {
        // Horizontal movement
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis > DEADZONE) {
            // Move right.
            RigidbodyComponent.AddForce(transform.right * Speed, ForceMode2D.Impulse);
            AnimatorComponent.SetInteger("direction", RIGHT);
        } else if (horizontalAxis < -DEADZONE) {
            // Move left.
            RigidbodyComponent.AddForce(-transform.right * Speed, ForceMode2D.Impulse);
            AnimatorComponent.SetInteger("direction", LEFT);
        } else {
            AnimatorComponent.SetInteger("direction", IDLE);
        }
        RigidbodyComponent.velocity = new Vector2(Mathf.Clamp(RigidbodyComponent.velocity.x, -MAX_SPEED, MAX_SPEED), RigidbodyComponent.velocity.y);

        // Test if in air
        bool inAir = true;
        foreach (Transform t1 in Platforms.transform) { // Iterate over platforms
            foreach (Transform t2 in t1) { // Find ground collider within each platform
                if (t2.gameObject.name == "Ground Collider" && PlayerFeetCollider.IsTouching(t2.gameObject.GetComponent<Collider2D>())) {
                    inAir = false;
                    break;
                }
            }
        }

        // Jumping movement
        float jumpAxis = Input.GetAxis("Jump");
        if (jumpAxis > DEADZONE && FuelLevel.GetValue() > FuelLevel.LowerBound) {
            RigidbodyComponent.AddForce(transform.up * JumpPower, ForceMode2D.Impulse);
            AudioClipSource.clip = JumpClip;
            AudioClipSource.Play();
            FuelLevel.ChangeValue(-FuelDepletionRate * Time.deltaTime);
        } else if (!inAir) {
            FuelLevel.ChangeValue(FuelDepletionRate * Time.deltaTime);
        }
        AnimatorComponent.SetBool("inAir", inAir);

        // Check enemy collisions
        if (SceneManager.GetActiveScene().name != "Title Screen") {// TODO Try to do this better.
            if (!IsHurt) {
                // TODO: This could be done with callbacks a bit nicer.  Not needed for jam, but better practice.
                foreach (Transform t1 in Enemies.transform) {
                    foreach (Transform t2 in t1) {
                        if (PlayerCollider.IsTouching(t2.gameObject.GetComponent<Collider2D>())) {
                            Health.Value--;
                            TimeOfEnemyCollision = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                            IsHurt = true;
                            RigidbodyComponent.velocity = new Vector2(-RigidbodyComponent.velocity.x, 0);
                            RigidbodyComponent.AddForce(transform.up * JumpPower * 10, ForceMode2D.Impulse);
                            AnimatorComponent.enabled = false;
                            SpriteRendererComponent.sprite = HurtSprite;
                            AudioClipSource.clip = HurtClip;
                            AudioClipSource.Play();
                            break;
                        }
                    }
                }
            } else {
                long elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - TimeOfEnemyCollision;
                if (elapsed % 400 < 200) {
                    SpriteRendererComponent.color = new Color(1, 1, 1, 1);
                } else {
                    SpriteRendererComponent.color = new Color(1, 0.5f, 0.5f, 1);
                }
                if (elapsed >= 2000) {
                    IsHurt = false;
                    AnimatorComponent.enabled = true;
                }
            }
        }
        
        // Check for death and respawn
        if (transform.position.y < -25.0f) {
            AudioClipSource.clip = HurtClip;
            AudioClipSource.Play();
        }
        if (Health.Value <= 0 || transform.position.y < -25.0f) {
            transform.position = InitialPosition;
            Health.Value = Health.InitialValue;
            FuelLevel.SetValue(FuelLevel.UpperBound);
            RigidbodyComponent.velocity = Vector2.zero;
            SpriteRendererComponent.color = new Color(1, 1, 1, 1);
            IsHurt = false;
            AnimatorComponent.enabled = true;

            // Respawn Fly men
            if (SceneManager.GetActiveScene().name != "Title Screen") {// TODO Try to do this better.
                foreach (Transform t1 in Enemies.transform) {
                    if (t1.gameObject.name != "Fly Men") continue;

                    foreach (Transform t2 in t1) {
                        t2.gameObject.GetComponent<FlyManController>().respawn();
                    }

                    break;
                }
            }
        }
    }

    public void OnGamePause() {
        PrePauseVelocity = RigidbodyComponent.velocity;
        RigidbodyComponent.constraints = RigidbodyConstraints2D.FreezeAll;
        AnimatorComponent.enabled = false;
    }

    public void OnGameUnpause() {
        RigidbodyComponent.constraints = RigidbodyConstraints2D.FreezeRotation;
        RigidbodyComponent.velocity = PrePauseVelocity;
        AnimatorComponent.enabled = true;
    }
}
