using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Controls the health display during gameplay.
*/
public class HealthDisplayController : MonoBehaviour {
    public HealthScriptableObject PlayerHealth;
    private Color Opaque = new Color(1, 1, 1, 1);
    private Color Transparent = new Color(1, 1, 1, 0);
    private List<Image> Images;

    void Start() {
        // Get handle on all health images.
        Images = new List<Image>();
        foreach (Transform t in transform) {
            Images.Add(t.gameObject.GetComponent<Image>());
        }
    }

    void Update() {
        // Set the visibility of each health icon every frame.
        // TODO: Replace with event callback.
        for (int i = 0; i < Images.Count; i++) {
            Images[i].color = (PlayerHealth.Value >= i+1 ? Opaque : Transparent);
        }
    }
}
