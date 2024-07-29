using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    public AudioSource playerFootAudio;
    public AudioClip footClip;
    bool playing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayFootSound()
    {
        if (!playing)
        {
            playing = true;
            playerFootAudio.PlayOneShot(footClip);
            playing = false;
        }
    }
}