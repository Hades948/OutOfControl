using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManController : MonoBehaviour {
    public float speed;
    public float jumpHeight;
    private Vector3 jumpPower;
    private Rigidbody2D rigidBody;
    private Collider2D flyManCollider;
    private GameObject platforms;

    private bool hasSpawned = false;

    void Start() {
        jumpPower = new Vector3(1.0f, jumpHeight, 1.0f);

        flyManCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        platforms = GameObject.Find("Platforms");
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
    }

    public void OnBecameVisible() {
        hasSpawned = true;
    }
}
