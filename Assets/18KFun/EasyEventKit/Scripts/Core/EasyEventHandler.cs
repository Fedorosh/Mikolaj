using System;

#if ENABLE_EASY_POOL_KIT
using EasyPoolKit;
#endif

namespace EasyEvent
{
    public sealed class EasyEventHandler
#if ENABLE_EASY_POOL_KIT
        : RecyclableObject
#endif
    {
        public int EventId { get; private set; }
        
        public bool IfValid { get; private set; }

        public EventHandler<EasyEventArgs> Handler { get; private set; }
        
        public void SetHandler(int eventId, EventHandler<EasyEventArgs> handler)
        {
            IfValid = true;
            EventId = eventId;
            Handler = handler;   
        }

        public void DispatchEvent(object sender, EasyEventArgs eventArgs)
        {
            Handler.Invoke(sender, eventArgs);
        }

        public bool IfContains(EventHandler<EasyEventArgs> handler)
        {
            return Handler == handler;
        }

        public void SetInvalid()
        {
            IfValid = false;
        }

        public void Clear()
        {
            Handler = null;
            IfValid = true;
            EventId = -1;
        }

#if ENABLE_EASY_POOL_KIT
        public override void OnObjectDespawn()
        {
            base.OnObjectDespawn();
            Clear();
        }
#endif
    }
}