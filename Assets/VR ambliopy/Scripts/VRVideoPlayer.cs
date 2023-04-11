using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using YoutubePlayer; // introduce iBitcha project settings. 


namespace VRAmbliopy
{

    public class VRVideoPlayer : MonoBehaviour
    {
        [Header("Video clip"),Space]
        [SerializeField] private VideoPlayer m_videoPlayer;
         

        [Header("Screen renderer"), Space]
        [SerializeField] private Renderer m_screenRenderer;



        public void Awake()
        {
            YoutubePlayer.YoutubeDl.ServerUrl = "http://138.4.10.35:3005";

        }

        

        public async void PrepareAsyncVideo()
        {
            await m_videoPlayer.PlayYoutubeVideoAsync("https://youtu.be/sfXPGuZ68HM"); // preparing it?

        }

  
        public void PlayVideo()
        {
            m_videoPlayer.Play();
            m_screenRenderer.material. color =Color.white;

        }

        public void PauseVideo()
        {
            m_videoPlayer.Pause();
            m_screenRenderer.material.color = Color.black;
        }

        public void StopVideo()
        {
            m_videoPlayer.Stop();
            m_screenRenderer.material.color = Color.black;

        }









    }


}
