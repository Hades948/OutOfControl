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


    void Start() {
        positionLeft = new Vector3(transform.position.x - width, transform.position.y, transform.position.z);
        positionRight = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
        targetPosition = positionLeft;
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition) {
            if (targetPosition == positionLeft) {
                targetPosition = positionRight;
            } else if (targetPosition == positionRight) {
                targetPosition = positionLeft;
            }
        }
    }
}
