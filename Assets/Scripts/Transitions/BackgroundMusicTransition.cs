using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transition
{

    public class BackgroundMusicTransition : MonoBehaviour
    {
        [SerializeField]
        private BGMRequestCollection bgmRequestCollection = null;
        [SerializeField]
        private MusicEvent musicEvent = null;
        [SerializeField]
        private bool playOnStart = false;
        [SerializeField]
        private SceneTransitionHandler sceneTransitionHandler = null;

        private void Awake()
        {
            sceneTransitionHandler.OnTransitionStart += FadeOutMusic;   
        }

        // Start is called before the first frame update
        void Start()
        {
            if (playOnStart)
            {
                bgmRequestCollection.Add(AudioBGM.Request(musicEvent));
            }
        }

        private void FadeOutMusic(float _time)
        {
            bgmRequestCollection.Add(AudioBGM.Request(musicEvent));
        }
    }

}