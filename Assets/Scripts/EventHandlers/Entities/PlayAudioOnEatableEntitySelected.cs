using Assets.Plugins.Game.Common;
using Assets.Scripts.Events.Entities;
using UnityDI;

namespace Assets.Scripts.EventHandlers.Entities
{
    public class PlayAudioOnEatableEntitySelected : EventHandlerBase<EntityEatableSelected>
    {
        [Dependency]
        public IAudioPlayer AudioPlayer { protected get; set; }

        public override void HandleEvent(EntityEatableSelected evt)
        {
            AudioPlayer.Play("eatable");
        }
    }
}
