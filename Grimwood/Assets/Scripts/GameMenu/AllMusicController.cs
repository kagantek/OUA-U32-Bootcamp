using UnityEngine;

public class AllMusicController : MonoBehaviour
{
    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    public void PauseAllMusic()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    public void ResumeAllMusic()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.UnPause();
            }
        }
    }
}
