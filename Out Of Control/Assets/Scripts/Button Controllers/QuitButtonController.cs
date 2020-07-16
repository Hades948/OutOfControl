using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonController : MonoBehaviour {
    public void OnButtonPress() {
        Application.Quit();
    }
}
