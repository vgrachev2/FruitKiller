using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Plugins.Game.Common;
using Assets.Scripts.Events.Entities;
using UnityDI;

namespace Assets.Scripts.EventHandlers.Entities
{
    public class PlayAudioOnNotEatableEntitySelected : EventHandlerBase<EntityNotEatableSelected>
    {
        [Dependency]
        public IAudioPlayer AudioPlayer { protected get; set; }

        public override void HandleEvent(EntityNotEatableSelected evt)
        {
            AudioPlayer.Play("notEatable");
        }
    }
}
