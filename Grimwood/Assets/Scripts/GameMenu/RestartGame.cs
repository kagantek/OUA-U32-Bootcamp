using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private AllMusicController _allMusicController;

    public void RestartScene()
    {
        Time.timeScale = 1f;
        _allMusicController.ResumeAllMusic();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
