using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

/**
* Controls the Wing Man enemy's behavior.
*/
public class WingManController : MonoBehaviour {
    /**
    * Vertical distance between the Spike Man's start point and furthest point.
    */
    public float Height;
    public float Speed;
    
    private Vector3 PositionAbove;
    private Vector3 PositionBelow;
    private Vector3 TargetPosition;
    private Animator AnimatorComponent;

    private bool IsPaused;

    // Speeds for the animator.
    private const float SPEED_UP = 0.95f;
    private const float SPEED_DOWN = 0.7f;


    void Start() {
        // Calculate target positions based on height.
        PositionAbove = new Vector3(transform.position.x, transform.position.y + Height, transform.position.z);
        PositionBelow = new Vector3(transform.position.x, transform.position.y - Height, transform.position.z);
        
        // Start Wing Man moving up.
        TargetPosition = PositionAbove;

        AnimatorComponent = gameObject.GetComponent<Animator>();
        AnimatorComponent.speed = SPEED_UP;
    }

    void FixedUpdate() {
        if (IsPaused) return; // TODO Use rigidbody on enemies.  Update this when that happens.

        // Update position.
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

        // Change direction and target if the current target has been reached.
        if (transform.position == TargetPosition) {
            if (TargetPosition == PositionAbove) {
                TargetPosition = PositionBelow;
                AnimatorComponent.speed = SPEED_DOWN;
            } else if (TargetPosition == PositionBelow) {
                TargetPosition = PositionAbove;
                AnimatorComponent.speed = SPEED_UP;
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
