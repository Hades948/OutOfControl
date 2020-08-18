using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/**
* Contains info about the game's state.  Persists throughout all scenes.
*/
public class GameManagerController : MonoBehaviour {
    public int LevelProgress = 1;

    private const string SAVE_DATA_PATH = "/save.dat";

    // ??? Is it best to do this on load?  It's being done here so that everything can be set
    // DontDestoryOnLoad before title screen is triggered in Start().
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        LoadGame();
        GameObject.Find("Black Fade").GetComponent<BlackFadeController>().FadeToScene("Title Screen");
    }

    void OnApplicationQuit() {
        // Auto save on game exit.
        SaveGame();
    }

    public void SaveGame() {
        // Set save data values
        SaveData data = new SaveData();
        data.LevelProgress = LevelProgress;

        // Save data file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + SAVE_DATA_PATH);
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame() {
        // Create save data w/ defaults if none exsits.
        if (!File.Exists(Application.persistentDataPath + SAVE_DATA_PATH)) {
            SaveGame();
        }

        // Open save data file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
        SaveData data = (SaveData) bf.Deserialize(file);
        file.Close();

        // Load stored values into game data.
        LevelProgress = data.LevelProgress;
    }
}
