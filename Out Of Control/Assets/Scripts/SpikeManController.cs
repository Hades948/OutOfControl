using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpikeManController : MonoBehaviour {
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
        PositionLeft = new Vector3(transform.position.x - Width, transform.position.y, transform.position.z);
        PositionRight = new Vector3(transform.position.x + Width, transform.position.y, transform.position.z);
        TargetPosition = PositionLeft;

        AnimatorComponent = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate() {
        if (IsPaused) return;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

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
