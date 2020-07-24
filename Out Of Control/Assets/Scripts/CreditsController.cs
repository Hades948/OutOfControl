using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {
    public float Speed;
    private BlackFadeController BlackFadeControllerScript;

    void Start() {
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
    }

    void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime, transform.position.z);
    }

    void OnBecameInvisible() {
        BlackFadeControllerScript.FadeToScene("Title Screen");
    }
}
