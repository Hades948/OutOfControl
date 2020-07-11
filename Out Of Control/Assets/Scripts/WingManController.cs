using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WingManController : MonoBehaviour {
    public float height;
    public float speed;
    private Vector3 positionAbove;
    private Vector3 positionBelow;
    private Vector3 targetPosition;


    void Start() {
        positionAbove = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        positionBelow = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
        targetPosition = positionAbove;
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (equateFloats(transform.position.y, targetPosition.y, .1f)) {
            if (targetPosition == positionAbove) {
                targetPosition = positionBelow;
            } else if (targetPosition == positionBelow) {
                targetPosition = positionAbove;
            }
        }
    }

    public static bool equateFloats(float f1, float f2, float tolerance) {
        return Abs(f1 - f2) < tolerance;
    }
}
