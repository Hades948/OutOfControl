using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WingManController : MonoBehaviour {
    public float height;
    public float speed;
    private const float SPEED_UP = 0.95f;
    private const float SPEED_DOWN = 0.7f;
    private Vector3 positionAbove;
    private Vector3 positionBelow;
    private Vector3 targetPosition;
    private Animator animator;
    private bool isPaused;


    void Start() {
        positionAbove = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        positionBelow = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
        targetPosition = positionAbove;

        animator = gameObject.GetComponent<Animator>();
        animator.speed = SPEED_UP;
    }

    void FixedUpdate() {
        if (isPaused) return; // TODO Use rigidbody on enemies.  Update this when that happens.

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition) {
            if (targetPosition == positionAbove) {
                targetPosition = positionBelow;
                animator.speed = SPEED_DOWN;
            } else if (targetPosition == positionBelow) {
                targetPosition = positionAbove;
                animator.speed = SPEED_UP;
            }
        }
    }

    public void OnGamePaused() {
        isPaused = true;
        animator.enabled = false;
    }

    public void OnGameUnpaused() {
        isPaused = false;
        animator.enabled = true;
    }
}
