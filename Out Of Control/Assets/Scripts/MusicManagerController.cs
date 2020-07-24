using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerController : MonoBehaviour {
    private static bool IsRunning = false;
    
    void Start() {
        if (IsRunning) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            IsRunning = true;
        }
    }
}
