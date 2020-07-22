using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WingManController : MonoBehaviour {
    public float Height;
    public float Speed;
    
    private Vector3 PositionAbove;
    private Vector3 PositionBelow;
    private Vector3 TargetPosition;
    private Animator AnimatorComponent;

    private bool IsPaused;

    private const float SPEED_UP = 0.95f;
    private const float SPEED_DOWN = 0.7f;


    void Start() {
        PositionAbove = new Vector3(transform.position.x, transform.position.y + Height, transform.position.z);
        PositionBelow = new Vector3(transform.position.x, transform.position.y - Height, transform.position.z);
        TargetPosition = PositionAbove;

        AnimatorComponent = gameObject.GetComponent<Animator>();
        AnimatorComponent.speed = SPEED_UP;
    }

    void FixedUpdate() {
        if (IsPaused) return; // TODO Use rigidbody on enemies.  Update this when that happens.

        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

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
