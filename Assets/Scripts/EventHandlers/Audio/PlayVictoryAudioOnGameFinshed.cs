using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Plugins.Game.Common;
using Assets.Scripts.EventHandlers.Entities;
using Assets.Scripts.Events;
using UnityDI;

namespace Assets.Scripts.EventHandlers.Audio
{
    public class PlayVictoryAudioOnGameFinshed : EventHandlerBase<GameFinished>
    {
        [Dependency]
        public IAudioPlayer AudioPlayer { protected get; set; }

        public override void HandleEvent(GameFinished evt)
        {
            AudioPlayer.PlayWithLoopPause("victory");
        }
    }
}
