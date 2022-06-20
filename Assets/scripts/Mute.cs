using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public AudioSource mixer;
    public Slider volume;
    float antVal;
    public GameObject cross;
    public void SetMute()
    {
        if(mixer.volume == 0){
            cross.SetActive(false);
            volume.value = antVal;
            mixer.volume = antVal;
        }
        else
        {
            antVal = mixer.volume;
            mixer.volume = 0;
            volume.value = 0;
            cross.SetActive(true);
        }
    }
}
