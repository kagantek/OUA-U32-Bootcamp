using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    AudioSource animationSound;

    private void Start()
    {
        animationSound = GetComponent<AudioSource>();

    }
    private void Update()
    {
        
    }

    private void Footstep()
    {
        animationSound.Play();
    }
}