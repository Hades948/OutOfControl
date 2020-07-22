using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManController : MonoBehaviour {
    public float Speed;
    public float JumpHeight;

    private Vector3 JumpPower;
    private Vector3 InitialPosition;
    private Rigidbody2D RigidbodyComponent;
    private Collider2D ColliderComponent;
    private Animator AnimatorComponent;
    private GameObject Platforms;
    private Vector2 PrePauseVelocity;

    private bool HasSpawned = false;
    private bool IsPaused = false;

    void Start() {
        JumpPower = new Vector3(1.0f, JumpHeight, 1.0f);
        
        RigidbodyComponent = gameObject.GetComponent<Rigidbody2D>();
        AnimatorComponent = gameObject.GetComponent<Animator>();
        Platforms = GameObject.Find("Platforms");

        // Iterate through object children to find feet collider.
        foreach (Transform t in transform) {
            if (t.gameObject.name == "Fly Man Feet Collider") {
                ColliderComponent = t.gameObject.GetComponent<BoxCollider2D>();
                break;
            }
        }

        InitialPosition = transform.position;
    }

    void FixedUpdate() {
        if (!HasSpawned) return;
        if (IsPaused) return;
        
        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);

        bool inAir = true;
        foreach (Transform t in Platforms.transform) {
            if (ColliderComponent.IsTouching(t.gameObject.GetComponent<Collider2D>())) {
                inAir = false;
                break;
            }
        }

        if (!inAir) {
            RigidbodyComponent.AddForce(JumpPower);
        }

        AnimatorComponent.SetBool("inAir", inAir);
    }

    void OnBecameVisible() {
        HasSpawned = true;
    }

    public void respawn() {
        HasSpawned = false;
        transform.position = InitialPosition;
        RigidbodyComponent.velocity = Vector2.zero;
    }

    public void OnGamePause() {
        PrePauseVelocity = RigidbodyComponent.velocity;
        RigidbodyComponent.constraints = RigidbodyConstraints2D.FreezeAll;
        AnimatorComponent.enabled = false;
        IsPaused = true;
    }

    public void OnGameUnpause() {
        RigidbodyComponent.constraints = RigidbodyConstraints2D.FreezeRotation;
        RigidbodyComponent.velocity = PrePauseVelocity;
        AnimatorComponent.enabled = true;
        IsPaused = false;
    }
}
