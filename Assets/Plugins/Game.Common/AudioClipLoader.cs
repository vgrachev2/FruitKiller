using System;
using UnityEngine;

namespace Assets.Plugins.Game.Common
{
    public class AudioClipLoader : IAudioClipLoader
    {
        private const string PathToAudioResources = "Audio/";

        public AudioClip Load(string name)
        {
            return (AudioClip)Resources.Load(PathToAudioResources + name);
        }
    }
}