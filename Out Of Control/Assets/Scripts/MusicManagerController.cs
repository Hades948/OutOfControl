using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* Attaches to a Music Manager object so that it doesn't get destroyed on load.
* Could be made more generic if needed.
*/
public class MusicManagerController : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
