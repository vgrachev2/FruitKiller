//C# Unity event manager that uses strings in a hashtable over delegates and events in order to
//allow use of events without knowing where and when they're declared/defined.
//by Billy Fletcher of Rubix Studios

using System;
using System.Collections;
using System.Linq;
using Assets.Scripts.EventHandlers.Entities;
using Assets.Scripts.Events.Entities;
using UnityDI;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public interface IEventHandler
    {
        void HandleEvent(object evt);
    }
    public interface IEventHandler<TE> : IEventHandler where TE : IEvent
    {
        new void HandleEvent(TE evt);
    }

    public interface IEvent
    {
    }

    public class EventManager : MonoBehaviour
    {
        public bool LimitQueueProcesing = false;
        public float QueueProcessTime = 0.0f;

        private static EventManager s_Instance = null;
        public static EventManager instance
        {
            get
            {
                if (s_Instance == null)
                {
                    GameObject go = new GameObject("EventManager");
                    s_Instance = (EventManager)go.AddComponent(typeof(EventManager));
                    var container = new ContainerInstaller().Install();
                    var handlers = s_Instance
                            .GetType()
                            .Assembly
                            .GetExportedTypes()
							.Where(type => !type.IsAbstract)
							.Where(x => x.GetInterface("IEventHandler`1") != null);
                    foreach (var handler in handlers)
                    {
                        var handlerInstance = (IEventHandler)Activator.CreateInstance(handler);
                        container.BuildUp(handlerInstance);
                        s_Instance.AddListener(handlerInstance,
                            handler.BaseType.GetGenericArguments()
                                .First(argument => argument.GetInterface("IEvent") != null)
                                .Name);
                    }
                }

                return s_Instance;
            }
        }

        private Hashtable m_listenerTable = new Hashtable();
        private Queue m_eventQueue = new Queue();


        //Add a handler to the event manager that will receive any events of the supplied event name.
        public bool AddListener(IEventHandler handler, string eventName)
        {
            if (handler == null || eventName == null)
            {
                Debug.Log("Event Manager: AddListener failed due to no handler or event name specified.");
                return false;
            }

            if (!m_listenerTable.ContainsKey(eventName))
                m_listenerTable.Add(eventName, new ArrayList());

            ArrayList listenerList = m_listenerTable[eventName] as ArrayList;

            listenerList.Add(handler);
            return true;
        }

        //Remove a handler from the subscribed to event.
        public bool DetachListener(IEventHandler<IEvent> handler, string eventName)
        {
            if (!m_listenerTable.ContainsKey(eventName))
                return false;

            ArrayList listenerList = m_listenerTable[eventName] as ArrayList;
            if (!listenerList.Contains(handler))
                return false;

            listenerList.Remove(handler);
            return true;
        }

        //Trigger the event instantly, this should only be used in specific circumstances,
        //the QueueEvent function is usually fast enough for the vast majority of uses.
        public bool TriggerEvent(IEvent evt)
        {
            string eventName = evt.GetType().Name;
            if (!m_listenerTable.ContainsKey(eventName))
            {
                Debug.Log("Event Manager: Event \"" + eventName + "\" triggered has no listeners!");
                return false; //No listeners for event so ignore it
            }

            ArrayList listenerList = m_listenerTable[eventName] as ArrayList;
            foreach (IEventHandler listener in listenerList)
            {
                listener.HandleEvent(evt);
            }

            return true;
        }

        //Inserts the event into the current queue.
        public bool QueueEvent(IEvent evt)
        {
            if (!m_listenerTable.ContainsKey(evt.GetType().Name))
            {
                Debug.Log("EventManager: QueueEvent failed due to no listeners for event: " + evt.GetType().Name);
                return false;
            }

            m_eventQueue.Enqueue(evt);
            return true;
        }

        //Every update cycle the queue is processed, if the queue processing is limited,
        //a maximum processing time per update can be set after which the events will have
        //to be processed next update loop.
        void Update()
        {
            float timer = 0.0f;
            while (m_eventQueue.Count > 0)
            {
                if (LimitQueueProcesing)
                {
                    if (timer > QueueProcessTime)
                        return;
                }

                IEvent evt = m_eventQueue.Dequeue() as IEvent;
                if (!TriggerEvent(evt))
                    Debug.Log("Error when processing event: " + evt.GetType().Name);

                if (LimitQueueProcesing)
                    timer += Time.deltaTime;
            }
        }

        public void OnApplicationQuit()
        {
            m_listenerTable.Clear();
            m_eventQueue.Clear();
            s_Instance = null;
        }
    }
}