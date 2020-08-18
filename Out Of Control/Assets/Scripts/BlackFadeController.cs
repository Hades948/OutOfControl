using UnityEngine;
using UnityEngine.SceneManagement;

/**
* Controls the Black Fade object for fading between scenes.
*/
public class BlackFadeController : MonoBehaviour {
    private int NextSceneIndex;

    /**
    * Fades to next scene based on build index.
    */
    public void FadeToNextScene() {
        FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /**
    * Fades to a given screen by name.
    */
    public void FadeToScene(string name) {
        FadeToScene(SceneUtility.GetBuildIndexByScenePath("Scenes/" + name));
    }

    /**
    * Fades to a given screen by build index.
    */
    public void FadeToScene(int index) {
        gameObject.GetComponent<Animator>().SetTrigger("Fade Out");
        NextSceneIndex = index;
    }

    /**
    * Callback for the animator to actually switch scenes after animation is finished.
    */
    public void OnFadeComplete() {
        SceneManager.LoadSceneAsync(NextSceneIndex);
    }
}
