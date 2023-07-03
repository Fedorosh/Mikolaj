using System;

#if ENABLE_EASY_POOL_KIT
using EasyPoolKit;
#endif

namespace EasyEvent
{
    public class ExampleEventArgs : EasyEventArgs
    {
        public static readonly int EventId = typeof(ExampleEventArgs).GetHashCode();

        public override int Id => EventId;

        public string ExampleName { get; private set; } = String.Empty;

        public int ExampleAge { get; private set; } = 0;

        public object ExampleExtraInfo { get; private set; } = null;

        public static ExampleEventArgs CreateEvent(string name, int age, object extraInfo)
        {
            var exampleEvent =
#if ENABLE_EASY_POOL_KIT
                ObjectPoolKit.Spawn<ExampleEventArgs>();
#else 
                new ExampleEventArgs();
#endif
            exampleEvent.ExampleName = name;
            exampleEvent.ExampleAge = age;
            exampleEvent.ExampleExtraInfo = extraInfo;

            return exampleEvent;
        }

        protected override void Clear()
        {
            ExampleName = string.Empty;
            ExampleAge = 0;
            ExampleExtraInfo = null;
        }
    }
}