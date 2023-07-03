#if ENABLE_EASY_POOL_KIT
using EasyPoolKit;
#endif

namespace EasyEvent
{
    public sealed partial class EasyEventGroup
    {
        public sealed class EasyEvent
#if ENABLE_EASY_POOL_KIT
            : RecyclableObject
#endif
        {
            public object Sender;
            public EasyEventArgs EventArgs;

            private void Clear()
            {
                Sender = null;
                EventArgs = null;
            }

            public static EasyEvent CreateEvent(object sender, EasyEventArgs eventArgs)
            {
                var newEvent =
#if ENABLE_EASY_POOL_KIT
                    ObjectPoolKit.Spawn<EasyEvent>();
#else
                    new EasyEvent();
#endif
                newEvent.Sender = sender;
                newEvent.EventArgs = eventArgs;
                return newEvent;
            }

            public static void DestroyEvent(EasyEvent easyEvent)
            {
#if ENABLE_EASY_POOL_KIT
                ObjectPoolKit.Despawn(easyEvent);
#endif
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
}