using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManController : MonoBehaviour {
    public float speed;
    public float jumpHeight;
    private Vector3 jumpPower;
    private Vector3 initialPosition;
    private Rigidbody2D rigidBody;
    private Collider2D flyManCollider;
    private Animator animator;
    private GameObject platforms;

    private bool hasSpawned = false;

    void Start() {
        jumpPower = new Vector3(1.0f, jumpHeight, 1.0f);
        
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        platforms = GameObject.Find("Platforms");

        // Iterate through object children to find feet collider.
        foreach (Transform t in transform) {
            if (t.gameObject.name == "Fly Man Feet Collider") {
                flyManCollider = t.gameObject.GetComponent<BoxCollider2D>();
                break;
            }
        }

        initialPosition = transform.position;
    }

    void FixedUpdate() {
        if (!hasSpawned) return;
        
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

        bool inAir = true;
        foreach (Transform t in platforms.transform) {
            if (flyManCollider.IsTouching(t.gameObject.GetComponent<Collider2D>())) {
                inAir = false;
                break;
            }
        }

        if (!inAir) {
            rigidBody.AddForce(jumpPower);
        }

        animator.SetBool("inAir", inAir);
    }

    public void OnBecameVisible() {
        hasSpawned = true;
    }

    public void respawn() {
        hasSpawned = false;
        transform.position = initialPosition;
        rigidBody.velocity = Vector2.zero;
    }
}
