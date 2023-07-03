using UnityEngine;

#if ENABLE_EASY_POOL_KIT
using EasyPoolKit; 
#endif

namespace EasyEvent.Demo
{
    public class Demo1_ChangeColorEventArgs : EasyEventArgs
    {
        public static readonly int EventId = typeof(Demo1_ChangeColorEventArgs).GetHashCode();

        public override int Id => EventId;

        public Color TextColor = Color.black;

        public static Demo1_ChangeColorEventArgs CreateEvent(Color color)
        {
            var newEvent =
#if ENABLE_EASY_POOL_KIT
                ObjectPoolKit.Spawn<Demo1_ChangeColorEventArgs>();
#else 
                new Demo1_ChangeColorEventArgs();
#endif
            newEvent.TextColor = color;
            return newEvent;
        }

        protected override void Clear()
        {
            TextColor = Color.black;
        }
    }
}