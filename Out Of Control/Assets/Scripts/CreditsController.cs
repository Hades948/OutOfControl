using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {
    public float speed;

    void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }
}
