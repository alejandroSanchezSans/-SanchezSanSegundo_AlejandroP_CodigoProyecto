using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolumeTotal : MonoBehaviour
{
    public Slider volumenSlider1, volumenSlider2;
    public void SetLevel(float sliderValue)
    {
        volumenSlider1.value = sliderValue;
        volumenSlider2.value = 1.0f - sliderValue;
    }
}
