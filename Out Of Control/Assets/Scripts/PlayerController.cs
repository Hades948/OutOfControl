using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const float DEADZONE = 0.1f;
    private Vector3 jumpPower;
    public float speed;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private GameObject platforms;

    void Start() {
        jumpPower = new Vector3(1.0f, 300.0f, 1.0f);
        
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        platforms = GameObject.Find("Platforms");
    }

    void FixedUpdate() {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float jumpAxis = Input.GetAxisRaw("Jump");

        // Horizontal movement
        if (hAxis > DEADZONE) {
            // Move right.
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        } else if (hAxis < -DEADZONE) {
            // Move left.
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        bool inAir = true;
        foreach (Transform t in platforms.transform) {
            if (playerCollider.IsTouching(t.gameObject.GetComponent<Collider2D>())) {
                inAir = false;
                break;
            }
        }

        // Jumping movement
        if (jumpAxis > DEADZONE && !inAir) {
            rigidBody.AddForce(jumpPower);
        }
    }
}
