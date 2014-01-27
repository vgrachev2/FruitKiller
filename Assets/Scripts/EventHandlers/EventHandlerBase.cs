using System;
using System.Linq;
using Assets.Scripts.Events;
using Assets.Scripts.Events.Entities;
using UnityEngine;

namespace Assets.Scripts.EventHandlers.Entities
{
    public abstract class EventHandlerBase<TEvent> : MonoBehaviour, IEventHandler<TEvent> where TEvent : IEvent
    {
        public abstract void HandleEvent(TEvent evt);

        public void HandleEvent(object evt)
        {
            HandleEvent((TEvent) evt);
        }
    }

}