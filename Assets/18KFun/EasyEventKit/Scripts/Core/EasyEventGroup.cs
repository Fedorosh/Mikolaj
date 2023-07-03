using System;
using System.Collections.Generic;

#if ENABLE_EASY_POOL_KIT
using EasyPoolKit;
#endif

namespace EasyEvent
{
    [Flags]
    public enum EventGroupStrictMode
    {
        NoStrict = 0x0,
        NotAllowNoHandler = 0x1,
        NoAllowMultiHandler = 0x2,
        NoAllowMultiSameHandler = 0x4,
    }

    public sealed partial class EasyEventGroup
    {
        public EventGroupStrictMode StrictMode { get; private set; } = EventGroupStrictMode.NoStrict;

        private readonly Dictionary<int, LinkedList<EasyEventHandler>> _eventHandlerDic = new Dictionary<int, LinkedList<EasyEventHandler>>();
        
        private readonly Queue<EasyEvent> _eventQueue = new Queue<EasyEvent>();

        private readonly Queue<LinkedListNode<EasyEventHandler>> _removeEventHandlers = new Queue<LinkedListNode<EasyEventHandler>>();

        private readonly Queue<LinkedListNode<EasyEventHandler>> _cachedEventHandlers = new Queue<LinkedListNode<EasyEventHandler>>();

        public int RegisteredEventCount => _eventHandlerDic.Count;
        
        public int EventQueueCount => _eventQueue.Count;

        public int CachedHandlerPoolCount => _cachedEventHandlers.Count;
        
        public EasyEventGroup(EventGroupStrictMode strictMode)
        {
            StrictMode = strictMode;
        }

        public void Register(int eventId, EventHandler<EasyEventArgs> handler)
        {
            if (handler == null)
            {
                throw new Exception("EasyEventKit == Handler should not be null!");
            }

            if (!_eventHandlerDic.ContainsKey(eventId))
            {
                _eventHandlerDic.Add(eventId, new LinkedList<EasyEventHandler>());
            }
            else
            {
                if ((StrictMode & EventGroupStrictMode.NoAllowMultiHandler) == EventGroupStrictMode.NoAllowMultiHandler)
                {
                    throw new Exception($"EasyEventKit == EventGroup's Strict Mode is {StrictMode.ToString()} but trying to register multiHandlers!");
                }

                if ((StrictMode & EventGroupStrictMode.NoAllowMultiSameHandler) == EventGroupStrictMode.NoAllowMultiSameHandler)
                {
                    if (IfHandlerExist(eventId, handler))
                    {
                        throw new Exception($"EasyEventKit == EventGroup's Strict Mode is {StrictMode.ToString()} but trying to register multiSameHandlers!");
                    }
                }
            }
            
            var handlerNode = SpawnHandlerNode(eventId, handler);
            _eventHandlerDic[eventId].AddLast(handlerNode);
        }

        public void Unregister(int eventId, EventHandler<EasyEventArgs> handler)
        {
            if (handler == null)
            {
                throw new Exception("EasyEventKit == Handler should not be null!");
            }

            if (!_eventHandlerDic.TryGetValue(eventId, out var handlers) || handlers.Count == 0)
            {
                throw new Exception($"EasyEventKit == Unregister {eventId.ToString()} but can't find!");
            }

            LinkedListNode<EasyEventHandler> handlerNode = handlers.First;

            while (handlerNode != null)
            {
                var handlerVal = handlerNode.Value;

                if (handlerVal.IfContains(handler))
                {
                    if (handlerVal.IfValid)
                    {
                        handlerVal.SetInvalid();
                        
                        // Do not remove at once but in a remove queue
                        _removeEventHandlers.Enqueue(handlerNode);
                        break;   
                    }
                }

                handlerNode = handlerNode.Next;
            }

            if (handlerNode == null)
            {
                throw new Exception($"EasyEventKit == Unregister {eventId.ToString()} but can't find!");
            }
        }

        public void UpdateKit(float deltaTime, float realDeltaTime)
        {
            while (_eventQueue.Count > 0)
            {
                var curEvent = _eventQueue.Dequeue();
                DispatchEventInternal(curEvent.Sender, curEvent.EventArgs);
                EasyEvent.DestroyEvent(curEvent);
            }
            
            //deal with removing events
            while (_removeEventHandlers.Count > 0)
            {
                var remHandler = _removeEventHandlers.Dequeue();
                RemoveHandlerInternal(remHandler);
            }
        }

        public void DispatchEvent(object sender, EasyEventArgs eventArgs)
        {
            DispatchEventInternal(sender, eventArgs);
        }

        public void DispatchEventAsync(object sender, EasyEventArgs eventArgs)
        {
            var eventData = EasyEvent.CreateEvent(sender, eventArgs);
            _eventQueue.Enqueue(eventData);            
        }

        private void DispatchEventInternal(object sender, EasyEventArgs eventArgs)
        {
            bool ifHaveHandler = false;

            if (_eventHandlerDic.TryGetValue(eventArgs.Id, out var handlers))
            {
                ifHaveHandler = true;

                LinkedListNode<EasyEventHandler> handlerNode = handlers.First;
                
                while (handlerNode != null)
                {
                    var handlerVal = handlerNode.Value;

                    if (handlerVal.IfValid)
                    {
                        handlerVal.DispatchEvent(sender, eventArgs);
                    }

                    handlerNode = handlerNode.Next;
                }
            }

#if ENABLE_EASY_POOL_KIT
            ObjectPoolKit.Despawn(eventArgs);
#endif
            if (!ifHaveHandler && (StrictMode & EventGroupStrictMode.NotAllowNoHandler) ==
                EventGroupStrictMode.NotAllowNoHandler)
            {
                throw new Exception("EasyEventKit == DispatchEvent but there's no handler!");
            }
        }

        public int GetHandlersCount(int eventId)
        {
            if (_eventHandlerDic.TryGetValue(eventId, out var handlers))
            {
                return handlers.Count;
            }

            return 0;
        }

        private bool IfHandlerExist(int eventId, EventHandler<EasyEventArgs> handler)
        {
            if (handler == null)
            {
                throw new Exception("EasyEventKit == Handler should not be null!");
            }
            
            if (_eventHandlerDic.TryGetValue(eventId, out var handlers))
            {
                var curHandler = handlers.First;
                
                while (curHandler != null)
                {
                    if (curHandler.Value.IfContains(handler))
                    {
                        return true;
                    }

                    curHandler = curHandler.Next;
                }
            }
            
            return false;
        }

        private void RemoveHandlerInternal(LinkedListNode<EasyEventHandler> removeNode)
        {
            var handler = removeNode.Value;
            
            if (_eventHandlerDic.TryGetValue(handler.EventId, out var handlers))
            {
                RemoveHandlerFromList(handlers, removeNode);
            }
        }

        private void RemoveHandlerFromList(LinkedList<EasyEventHandler> handlerList, LinkedListNode<EasyEventHandler> removeNode)
        {
            var handlerNode = handlerList.First;
            
            while (handlerNode != null)
            {
                if (removeNode == handlerNode)
                {
                    break;
                }

                handlerNode = handlerNode.Next;
            }
                
            if (handlerNode != null)
            {
                handlerList.Remove(handlerNode);
                DespawnHandlerNode(handlerNode);
            }
        }

        private LinkedListNode<EasyEventHandler> SpawnHandlerNode(int eventId, EventHandler<EasyEventArgs> handler)
        {
            var eventHandler =
#if ENABLE_EASY_POOL_KIT
                ObjectPoolKit.Spawn<EasyEventHandler>();
#else
                new EasyEventHandler();
#endif
            eventHandler.SetHandler(eventId, handler);

            if (_cachedEventHandlers.Count == 0)
            {
                _cachedEventHandlers.Enqueue(new LinkedListNode<EasyEventHandler>(null));
            }

            var handlerNode = _cachedEventHandlers.Dequeue();
            handlerNode.Value = eventHandler;
            return handlerNode;
        }

        private void DespawnHandlerNode(LinkedListNode<EasyEventHandler> handler)
        {
#if ENABLE_EASY_POOL_KIT
            ObjectPoolKit.Despawn(handler.Value);
#endif
            handler.Value = null;
            _cachedEventHandlers.Enqueue(handler);
        }

        public void ClearEventGroup(bool ifDestroyAll)
        {
            while (_eventQueue.Count > 0)
            {
                var curEvent = _eventQueue.Dequeue();
#if ENABLE_EASY_POOL_KIT
                ObjectPoolKit.Despawn(curEvent.EventArgs);
#endif
                EasyEvent.DestroyEvent(curEvent);
            }

            //No Need
            // _eventQueue.Clear();

            foreach (var handlerPair in _eventHandlerDic)
            {
                var handlerList = handlerPair.Value;
                var curHandlerNode = handlerList.First;
                
                while (curHandlerNode != null)
                {
                    var nextNode = curHandlerNode.Next;
                    RemoveHandlerFromList(handlerList, curHandlerNode);
                    curHandlerNode = nextNode;
                }
            }

            if (ifDestroyAll)
            {
                _eventHandlerDic.Clear();
            }
            
            while (_removeEventHandlers.Count > 0)
            {
                var remHandler = _removeEventHandlers.Dequeue();
                RemoveHandlerInternal(remHandler);
            }
            
            //No Need
            // _removeEventHandlers.Clear();

            if (ifDestroyAll)
            {
                _cachedEventHandlers.Clear();
            }
        }

        public void DebugLoopEventDic(Action<int, int> onLoop)
        {
            foreach (var eventInfo in _eventHandlerDic)
            {
                var handlerCount = 0;
                var curHandler = eventInfo.Value.First;
                while (curHandler != null)
                {
                    if (curHandler.Value.IfValid)
                    {
                        handlerCount++;
                    }
                    curHandler = curHandler.Next;
                }
                onLoop?.Invoke(eventInfo.Key, handlerCount);
            }
        }
    }
}