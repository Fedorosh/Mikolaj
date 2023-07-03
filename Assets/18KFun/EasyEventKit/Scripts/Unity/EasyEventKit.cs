using System;
using UnityEngine;

namespace EasyEvent
{
    public sealed class EasyEventKit
    {
        public static readonly EasyEventKit Instance = new EasyEventKit();
        
        private readonly EasyEventGroup _eventGroup;

        public int RegisteredEventCount => _eventGroup.RegisteredEventCount;
        
        public int EventQueueCount => _eventGroup.EventQueueCount;

        public int CachedHandlerPoolCount => _eventGroup.CachedHandlerPoolCount;

        private EasyEventKit()
        {
            EventGroupStrictMode strictMode = 
#if UNITY_EDITOR
                EventGroupStrictMode.NoAllowMultiSameHandler;
#else
                EventGroupStrictMode.NoStrict;
#endif
            _eventGroup = new EasyEventGroup(strictMode);
            
            CreateEventWorker();
        }

        /// <summary>
        /// Register the event handler
        /// </summary>
        public void Register(int eventId, EventHandler<EasyEventArgs> handler)
        {
            _eventGroup.Register(eventId, handler);
        }

        /// <summary>
        /// Unregister the event handler
        /// </summary>
        public void Unregister(int eventId, EventHandler<EasyEventArgs> handler)
        {
            _eventGroup.Unregister(eventId, handler);
        }

        /// <summary>
        /// It will dispatch the event right now, but thread unsafe.
        /// </summary>
        public void DispatchEvent(object sender, EasyEventArgs eventArgs)
        {
            _eventGroup.DispatchEvent(sender, eventArgs);
        }

        /// <summary>
        /// It will dispatch the event in an event queue at next frame.
        /// It's thread safe.
        /// </summary>
        public void DispatchEventAsync(object sender, EasyEventArgs eventArgs)
        {
            _eventGroup.DispatchEventAsync(sender, eventArgs);
        }

        /// <summary>
        /// Call the update method in your own code.
        /// This method will deal with the event queue and removing the unregistered handlers.
        /// </summary>
        public void UpdateKit(float deltaTime, float realDeltaTime)
        {
            _eventGroup.UpdateKit(deltaTime, realDeltaTime);
        }

        /// <summary>
        /// Find the count of handlers of an event
        /// </summary>
        public int GetHandlersCount(int eventId)
        {
            return _eventGroup.GetHandlersCount(eventId);
        }

        /// <summary>
        /// It will shut down the Event Kit.
        /// You can call this when you want to restart the game.
        /// </summary>
        public void ClearEventKit(bool ifDestroyAll)
        {
            _eventGroup.ClearEventGroup(ifDestroyAll);
        }
        
        /// <summary>
        /// Create the default worker to execute the Update method.
        /// You can replace it with your own modules.
        /// But be careful with the execution order of your own module!
        /// </summary>
        private void CreateEventWorker()
        {
            var eventWorker = new GameObject("EasyEventWorker");
            eventWorker.AddComponent<EasyEventWorker>();
            UnityEngine.Object.DontDestroyOnLoad(eventWorker);
        }

        /// <summary>
        /// Loop Show the debug info.
        /// Only valid in editor.
        /// </summary>
        /// <param name="onLoop"></param>
        public void DebugLoopDic(Action<int, int> onLoop)
        {
#if UNITY_EDITOR
            _eventGroup.DebugLoopEventDic(onLoop);
#endif
        }
    }
}