using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Assets.Plugins.Game.Common
{
    public class AudioPlayer:MonoBehaviour,IAudioPlayer
    {
        public AudioClipLoader AudioClipLoader { get; set; }

        public void Play(string name)
        {
			AudioClipLoader = new AudioClipLoader ();
            var audioClip = AudioClipLoader.Load(name);
			var gameObject = GameObject.FindWithTag("MainCamera");
			if (gameObject != null) {
				gameObject.audio.PlayOneShot (audioClip, 0.7f);

			}
           
        }

        public void PlayLoop(string name)
        {
            AudioClipLoader = new AudioClipLoader();
            var audioClip = AudioClipLoader.Load(name);
            var gameObject = GameObject.FindWithTag("MainCamera");
            if (gameObject != null)
            {
                gameObject.audio.loop = true;
                gameObject.audio.clip = audioClip;
                gameObject.audio.Play();

            }
          
        }
    }
}
