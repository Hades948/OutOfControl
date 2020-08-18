using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Attaches to the credits game object to scroll the credits.
*/
public class CreditsController : MonoBehaviour {
    public float Speed;
    private BlackFadeController BlackFadeControllerScript;

    void Start() {
        BlackFadeControllerScript = GameObject.Find("Black Fade").GetComponent<BlackFadeController>();
    }

    void Update() {
        // Update position based on speed.
        transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime, transform.position.z);
    }

    void OnBecameInvisible() {
        // Automatically fade to title screen after credits are over.
        BlackFadeControllerScript.FadeToScene("Title Screen");
    }
}
