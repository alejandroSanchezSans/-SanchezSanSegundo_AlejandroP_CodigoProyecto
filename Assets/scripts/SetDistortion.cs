using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDistortion : MonoBehaviour
{
    public AudioDistortionFilter distortion;
    public void SetLevel(float sliderValue)
    {
        distortion.distortionLevel = sliderValue;
    }
}
