using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    public AudioSource playerFootAudio;
    public AudioClip footClip;
    private bool playing;
    void Start()
    {
        playerFootAudio.spatialBlend = 0;
        playerFootAudio.volume = 1.0f;
    }

    public void PlayFootSound()
    {
        if (!playing)
        {
            StartCoroutine(PlayFootstepSoundCoroutine());
        }
    }

    private IEnumerator PlayFootstepSoundCoroutine()
    {
        playing = true;
        playerFootAudio.PlayOneShot(footClip);
        yield return new WaitForSeconds(footClip.length);
        playing = false;
    }
}