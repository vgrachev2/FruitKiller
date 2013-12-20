using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Plugins.Game.Common;
using Game.Common;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class OnDestroyAudioBehavior : AudioBehaviorBase
    {
        [Dependency]
        public IAudioPlayer AudioPlayer2 { private get; set; }
        void OnDestroy()
        {
			Debug.Log ("1");
            AudioPlayer2.Play(AudioName);
			Debug.Log ("2");
        } 
    }
}
