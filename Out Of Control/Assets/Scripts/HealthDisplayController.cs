using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayController : MonoBehaviour {
    public HealthScriptableObject health;
    private Color opaque = new Color(1, 1, 1, 1);
    private Color transparent = new Color(1, 1, 1, 0);
    private List<Image> images;

    void Start() {
        images = new List<Image>();

        foreach (Transform t in transform) {
            images.Add(t.gameObject.GetComponent<Image>());
        }
    }

    void Update() {
        for (int i = 0; i < images.Count; i++) {
            images[i].color = (health.value >= i+1 ? opaque : transparent);
        }
    }
}
