using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByPass : MonoBehaviour
{
    public AudioSource mixer;
    public void SetLevel(float sliderValue)
    {
        if (sliderValue > 0.5f)
        {
            mixer.bypassEffects = true;
        }
        else
        {
            mixer.bypassEffects = false;
        }
        
    }
}
