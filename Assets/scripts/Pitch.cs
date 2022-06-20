using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Pitch : MonoBehaviour
{
    //public AudioSource mixer;
    public VideoPlayer video;
    public void SetLevel(float sliderValue)
    {
        //mixer.pitch = sliderValue;
        video.playbackSpeed = sliderValue;
    }
}
