using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioSource battleMusicSource;
    public AudioClip backgroundMusic;
    public AudioClip battleMusic;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        backgroundMusicSource.clip = backgroundMusic;
        battleMusicSource.clip = battleMusic;
        backgroundMusicSource.loop = true;
        battleMusicSource.loop = true;
        backgroundMusicSource.volume = 0;
        battleMusicSource.volume = 0;
        backgroundMusicSource.Play();
        StartCoroutine(FadeIn(backgroundMusicSource, fadeDuration));
    }

    public void StartBattleMusic()
    {
        StartCoroutine(SwitchMusic(backgroundMusicSource, battleMusicSource, fadeDuration));
    }

    public void StopBattleMusic()
    {
        StartCoroutine(SwitchMusic(battleMusicSource, backgroundMusicSource, fadeDuration));
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        float startVolume = 0;
        float targetVolume = 1.0f;
        float currentTime = 0;

        audioSource.volume = startVolume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        float targetVolume = 0;
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
        audioSource.Stop();
    }

    private IEnumerator SwitchMusic(AudioSource from, AudioSource to, float duration)
    {
        yield return StartCoroutine(FadeOut(from, duration));
        to.Play();
        yield return StartCoroutine(FadeIn(to, duration));
    }
}
