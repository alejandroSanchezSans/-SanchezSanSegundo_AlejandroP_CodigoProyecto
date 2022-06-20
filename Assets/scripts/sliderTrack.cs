using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class sliderTrack : MonoBehaviour
{


    Slider slider;
    bool slideMoviendo = false;
    public VideoPlayer videoPlayer;

    void Start() {
        slider = GetComponent<Slider>();
            
            }


   
    public void OnPointerDown(PointerEventData a)
    {
        slideMoviendo = true;

    }
    public void OnPointerUp(PointerEventData a)
    {
        float frame = (float)slider.value * (float)videoPlayer.frameCount;
        videoPlayer.frame = (long)frame;
        slideMoviendo = false;

    }
 void Update()
    {

        if (!slideMoviendo)
        {

            slider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }
}
