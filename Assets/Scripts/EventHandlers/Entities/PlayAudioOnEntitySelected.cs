using System;
using System.Linq;
using Assets.Scripts.Events;
using Assets.Scripts.Events.Entities;
using UnityEngine;

namespace Assets.Scripts.EventHandlers.Entities
{
    public class PlayAudioOnEntitySelected : EventHandlerBase<EnitySelected>
    {
        public override void HandleEvent(EnitySelected evt)
        {
            Debug.Log("sadasdsaddsd");
        }
    }

}