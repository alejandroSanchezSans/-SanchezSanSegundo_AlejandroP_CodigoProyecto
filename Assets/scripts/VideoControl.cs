using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

namespace YoutubePlayer
{

    public class VideoControl : MonoBehaviour
    {
        public YoutubePlayer youtubePlayer;
        VideoPlayer videoPlayer;
        public YoutubeVideoMetaData ytvideometaData;
        public Button btn_play;
        public Button btn_pause;
        public Button btn_search;
        public GameObject inputBusqueda;
        string api_youtube = "AIzaSyACV_JEiOC7ts8R0lJFEjOvM3dAaKHHmMU";
        string url_youtube = "https://www.googleapis.com/youtube/v3/search";
        public string busqueda;
        string type = "video";
        string part = "id,snippet";
        string videoURL = "https://www.youtube.com/watch?v=";
        public Slider slider;
        public Text nombrePista;

        private void Awake()
        {

            btn_play.interactable = false;
            btn_pause.interactable = false;
            btn_search.interactable = true;
            videoPlayer = youtubePlayer.GetComponent<VideoPlayer>();
            videoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;

        }
        void VideoPlayerPreparedCompleted(VideoPlayer source)
        {

            btn_play.interactable = source.isPrepared;
            btn_pause.interactable = source.isPrepared;
            



        }
        public async void Prepare()
        {
            btn_search.interactable = false;
            videoURL = "https://www.youtube.com/watch?v=";
            busqueda = inputBusqueda.GetComponent<TMP_InputField>().text;
            url_youtube += "?key=" + api_youtube + "&part=" + part + "&order=relevance&q=" + busqueda + "&type=" + type;
            UnityWebRequest www = UnityWebRequest.Get(url_youtube);
            StartCoroutine(getVideo(url_youtube));
            SSTools.ShowMessage("Cargando vídeo. Espere...", SSTools.Position.bottom, SSTools.Time.twoSecond);
            



        }

        IEnumerator getVideo(string url)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string[] resultados_ID = www.downloadHandler.text.Split("videoId");
                string[] resultadoFinal = resultados_ID[1].Replace("\":", "").Split("},");
                string idVideo = resultadoFinal[0].Replace("\"", "");
                videoURL += idVideo.Trim();
                prepareVideo(videoURL);

            }
        }


        public void PlayVideo()
        {
            
            videoPlayer.Play();
        }
        public void PauseVideo()
        {
            videoPlayer.Pause();
        }
        void onDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;

        }

        public async void prepareVideo(string url)
        {
            try
            {

                await youtubePlayer.PrepareVideoAsync(videoURL);

                SSTools.ShowMessage("Vídeo cargado.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                btn_search.interactable = true;
                print("video cargado");
                nombrePista.text = "Reproduciendo: " + busqueda;
                


            }
            catch
            {
                SSTools.ShowMessage("Vídeo no cargado.", SSTools.Position.bottom, SSTools.Time.twoSecond);

                print("Video no cargado.");
                btn_search.interactable = true;
            }
        }

        public void add10sMore()
        {
            videoPlayer.time = videoPlayer.time + 10;
        }

        public void add10sLess()
        {
            videoPlayer.time = videoPlayer.time - 10;
        }

        void Update()
        {

            if (videoPlayer.isPlaying)
            {
                ulong duration = videoPlayer.frameCount / (ulong)videoPlayer.frameRate;
                slider.value = (float)(videoPlayer.time / duration);
            }
        }


    }



}

