using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipVideoScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject button;
    public GameObject logoImage;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        button.SetActive(false);
        logoImage.SetActive(false);
    }

    void OnVideoEnd(VideoPlayer vp)
    {        Debug.Log("Video Bitti");
        button.SetActive(true);
        logoImage.SetActive(true);
    }
}
