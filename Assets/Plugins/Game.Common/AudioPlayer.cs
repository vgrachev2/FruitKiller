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
        private string _lastPlayingTrackName;
        public AudioClipLoader AudioClipLoader { get; set; }
        private const string SoundTag = "SoundManager";
        private GameObject _source;

        public GameObject Source{
            get{
                if (_source == null){
                    _source = GameObject.FindWithTag(SoundTag);
                }
                return _source;
            }
        }


        public void Play(string name)
        {
			AudioClipLoader = new AudioClipLoader ();
            var audioClip = AudioClipLoader.Load(name);
            Source.audio.PlayOneShot (audioClip, 0.7f);
        }



        public void PlayLoop(string name){
            if (_lastPlayingTrackName != name){
                AudioClipLoader = new AudioClipLoader();
                var audioClip = AudioClipLoader.Load(name);
                _lastPlayingTrackName = name;
                Source.audio.loop = true;
                 Source.audio.clip = audioClip;
                Source.audio.Play();
            }

        }


        public void SetVolume(float volume)
        {
           Source.audio.volume=volume;
        }


        public float GetVolume()
        {
            return Source.audio.volume;
        }


        public void PlayWithLoopPause(string name)
        {
            if (Source.audio.isPlaying){
                Source.audio.Stop();
            }
            Play(name);
            _lastPlayingTrackName = "";
            //Source.audio.Play();
        }
    }
}
