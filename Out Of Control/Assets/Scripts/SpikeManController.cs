using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

/**
* Controls the Spike Man enemy's behavior.
*/
public class SpikeManController : MonoBehaviour {
    /**
    * Horizontal distance between the Spike Man's start point and furthest point.
    */
    public float Width;
    public float Speed;

    private Vector3 PositionLeft;
    private Vector3 PositionRight;
    private Vector3 TargetPosition;
    private Animator AnimatorComponent;

    private bool IsPaused;

    private const int LEFT = 0;
    private const int RIGHT = 1;


    void Start() {
        // Calculate target positions based on width.
        PositionLeft = new Vector3(transform.position.x - Width, transform.position.y, transform.position.z);
        PositionRight = new Vector3(transform.position.x + Width, transform.position.y, transform.position.z);

        // Start Spike Man moving left.
        TargetPosition = PositionLeft;

        AnimatorComponent = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate() {
        if (IsPaused) return;

        // Update position.
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

        // Change direction and target if the current target has been reached.
        if (transform.position == TargetPosition) {
            if (TargetPosition == PositionLeft) {
                TargetPosition = PositionRight;
                AnimatorComponent.SetInteger("Direction", RIGHT);
            } else if (TargetPosition == PositionRight) {
                TargetPosition = PositionLeft;
                AnimatorComponent.SetInteger("Direction", LEFT);
            }
        }
    }

    public void OnGamePaused() {
        IsPaused = true;
        AnimatorComponent.enabled = false;
    }

    public void OnGameUnpaused() {
        IsPaused = false;
        AnimatorComponent.enabled = true;
    }
}
