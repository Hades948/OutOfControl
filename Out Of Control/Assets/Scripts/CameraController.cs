using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private GameObject Player;

    void Start() {
        Player = GameObject.Find("Player");
    }

    void Update() {
        Vector3 playerPos = Player.transform.position;
        
        float x = playerPos.x;
        x = Mathf.Clamp(x, 0.0f, 200.0f); // TODO This will need changed with different-sized levels.
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
