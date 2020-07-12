using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFadeController : MonoBehaviour {
    public void fadeToNextScene() {
        gameObject.GetComponent<Animator>().SetTrigger("Fade Out");
    }

    public void onFadeComplete() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
