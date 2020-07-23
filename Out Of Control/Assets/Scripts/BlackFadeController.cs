using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFadeController : MonoBehaviour {
    private int NextSceneIndex;

    public void FadeToNextScene() {
        FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToScene(string name) {
        FadeToScene(SceneUtility.GetBuildIndexByScenePath("Scenes/" + name));
    }

    public void FadeToScene(int index) {
        gameObject.GetComponent<Animator>().SetTrigger("Fade Out");
        NextSceneIndex = index;
    }

    public void OnFadeComplete() {
        SceneManager.LoadSceneAsync(NextSceneIndex);
    }
}
