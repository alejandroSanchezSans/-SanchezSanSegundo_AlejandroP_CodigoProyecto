
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume : MonoBehaviour {
    public AudioSource mixer;
    public void SetLevel (float sliderValue)
    {
        mixer.volume = sliderValue;
    }

   
}
