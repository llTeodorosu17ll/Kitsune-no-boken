using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void OpenScene(int sceneId) {
		SceneManager.LoadScene(sceneId);
        Time.timeScale = 1;
    }
}