using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject objectToHide;
    private bool isVisible = false;

    private bool isPaused = false;

    [SerializeField] private AllMusicController _allMusicController;

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            ShowPauseMenu();

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _allMusicController.PauseAllMusic();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _allMusicController.ResumeAllMusic();
        isPaused = false;
    }

    public void ShowPauseMenu()
    {
            isVisible = !isVisible;
            objectToHide.SetActive(isVisible);
    }

    public void BeackToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}
