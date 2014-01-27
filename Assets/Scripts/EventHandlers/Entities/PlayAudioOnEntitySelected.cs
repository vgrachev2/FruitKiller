using System;
using System.Linq;
using Assets.Plugins.Game.Common;
using Assets.Scripts.Events;
using Assets.Scripts.Events.Entities;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.EventHandlers.Entities
{
    public class PlayAudioOnEntitySelected : EventHandlerBase<EnitySelected>
    {
        [Dependency]
        public IAudioPlayer AudioPlayer { protected get; set; }

        public override void HandleEvent(EnitySelected evt)
        {
            AudioPlayer.Play("click01");
        }
    }

}