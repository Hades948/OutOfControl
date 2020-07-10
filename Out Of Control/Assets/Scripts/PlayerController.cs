using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const float DEADZONE = 0.1f;
    public float speed;
    void Start() {
        
    }

    void FixedUpdate() {
        float hAxis = Input.GetAxisRaw("Horizontal");

        if (hAxis > DEADZONE) {
            // Move right.
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        } else if (hAxis < -DEADZONE) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
    }
}
