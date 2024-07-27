using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource battleMusic;

    public float fadeDuration = 1.0f;

    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private AudioSource fadingInSource = null;
    private AudioSource fadingOutSource = null;
    private float fadeSpeed;
    private float currentFadeTime = 0f;

    private void Start()
    {
        // Baþlangýçta backgroundMusic'in sesi kapalý
        backgroundMusic.volume = 0;
        backgroundMusic.Play();
        StartFadeIn(backgroundMusic);
    }

    private void Update()
    {
        if (isFadingIn)
        {
            FadeIn();
        }
        if (isFadingOut)
        {
            FadeOut();
        }
    }

    public void StartBattleMusic()
    {
        if (!isFadingOut)
        {
            StartFadeOut(backgroundMusic);
        }

        if (!isFadingIn && !battleMusic.isPlaying)
        {
            StartFadeIn(battleMusic);
        }
    }

    public void StopBattleMusic()
    {
        if (!isFadingOut)
        {
            StartFadeOut(battleMusic);
        }

        if (!isFadingIn && !backgroundMusic.isPlaying)
        {
            StartFadeIn(backgroundMusic);
        }
    }

    private void StartFadeIn(AudioSource audioSource)
    {
        fadingInSource = audioSource;
        fadingInSource.volume = 0;
        fadeSpeed = 1f / fadeDuration;
        isFadingIn = true;
        fadingInSource.Play();
    }

    private void StartFadeOut(AudioSource audioSource)
    {
        fadingOutSource = audioSource;
        fadeSpeed = 1f / fadeDuration;
        isFadingOut = true;
    }

    private void FadeIn()
    {
        if (fadingInSource != null)
        {
            fadingInSource.volume += fadeSpeed * Time.deltaTime;
            if (fadingInSource.volume >= 1.0f)
            {
                fadingInSource.volume = 1.0f;
                isFadingIn = false;
                fadingInSource = null;
            }
        }
    }

    private void FadeOut()
    {
        if (fadingOutSource != null)
        {
            fadingOutSource.volume -= fadeSpeed * Time.deltaTime;
            if (fadingOutSource.volume <= 0.0f)
            {
                fadingOutSource.volume = 0.0f;
                isFadingOut = false;
                fadingOutSource.Stop();
                fadingOutSource = null;
            }
        }
    }
}
