using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject objectToHide;
    [SerializeField] private AllMusicController _allMusicController;

    void Start()
    {
        objectToHide.SetActive(false);        
    }

    public void ShowGameOverMenu()
    {        
        Time.timeScale = 0f;
        _allMusicController.PauseAllMusic();
        objectToHide.SetActive(true);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        _allMusicController.ResumeAllMusic();
        objectToHide.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
