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
    public class AudioBehaviorBase : MonoBehaviour
    {
        public string AudioName { get; set; }

        [Dependency]
        public IAudioPlayer AudioPlayer { protected get; set; }

        [Dependency]
        public ITouchConroller Conroller { protected get; set; }

    }
}
