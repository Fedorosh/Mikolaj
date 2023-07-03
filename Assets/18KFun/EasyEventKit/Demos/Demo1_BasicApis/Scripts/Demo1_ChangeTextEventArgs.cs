using System;

#if ENABLE_EASY_POOL_KIT
using EasyPoolKit; 
#endif

namespace EasyEvent.Demo
{
    public class Demo1_ChangeTextEventArgs : EasyEventArgs
    {
        public static readonly int EventId = typeof(Demo1_ChangeTextEventArgs).GetHashCode();

        public override int Id => EventId;

        public string TextStr = string.Empty;

        public static Demo1_ChangeTextEventArgs CreateEvent(string str)
        {
            var newEvent =
#if ENABLE_EASY_POOL_KIT
                ObjectPoolKit.Spawn<Demo1_ChangeTextEventArgs>();
#else 
                new Demo1_ChangeTextEventArgs();
#endif
            newEvent.TextStr = str;
            return newEvent;
        }

        protected override void Clear()
        {
            TextStr = String.Empty;
        }
    }
}