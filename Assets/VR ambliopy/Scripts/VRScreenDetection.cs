using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; //??


namespace VRAmbliopy{

    public class VRScreenDetection : MonoBehaviour
    {

        [SerializeField] VRVideoPlayer m_videoPlayer;
        [SerializeField] bool m_isLooking;
        


        public void OnTriggerEnter(Collider other)
        { 
            if (other.CompareTag("Screen"))
            {
                Debug.Log("Está tocando la pantalla");
                m_videoPlayer.PlayVideo();
                m_isLooking = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            m_isLooking = false;
            Debug.Log("You have to look to the screen");
            m_videoPlayer.PauseVideo();
        }





    }


}

