using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpikeManController : MonoBehaviour {
    public float width;
    public float speed;
    private Vector3 positionLeft;
    private Vector3 positionRight;
    private Vector3 targetPosition;
    private Animator animator;
    private const int LEFT = 0;
    private const int RIGHT = 1;


    void Start() {
        positionLeft = new Vector3(transform.position.x - width, transform.position.y, transform.position.z);
        positionRight = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
        targetPosition = positionLeft;

        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition) {
            if (targetPosition == positionLeft) {
                targetPosition = positionRight;
                animator.SetInteger("Direction", RIGHT);
            } else if (targetPosition == positionRight) {
                targetPosition = positionLeft;
                animator.SetInteger("Direction", LEFT);
            }
        }
    }
}
