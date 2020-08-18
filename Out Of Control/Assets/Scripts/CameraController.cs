using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Controls the game camera.
*/
public class CameraController : MonoBehaviour {
    private GameObject Player;

    void Start() {
        Player = GameObject.Find("Player");
    }

    void Update() {
        // Get play position
        Vector3 playerPos = Player.transform.position;
        
        // Clamp camera position on the sides of levels.
        float x = playerPos.x;
        x = Mathf.Clamp(x, 0.0f, 200.0f); // TODO This will need changed with different-sized levels.

        // Update camera position.
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
