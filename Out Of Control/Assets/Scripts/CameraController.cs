using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        Vector3 playerPos = player.transform.position;
        
        float x = playerPos.x;
        x = Mathf.Clamp(x, 0.0f, 1000.0f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
