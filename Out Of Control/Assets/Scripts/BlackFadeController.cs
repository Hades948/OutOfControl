using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFadeController : MonoBehaviour {
    public void FadeToNextScene() {
        gameObject.GetComponent<Animator>().SetTrigger("Fade Out");
    }

    public void OnFadeComplete() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
