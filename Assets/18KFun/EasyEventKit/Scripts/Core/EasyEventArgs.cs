using System;

#if ENABLE_EASY_POOL_KIT
using EasyPoolKit;
#endif

namespace EasyEvent
{
    public abstract class EasyEventArgs : EventArgs
#if ENABLE_EASY_POOL_KIT
        , IRecyclable
#endif
    {
        public abstract int Id { get; }

        protected virtual void Clear(){}

#if ENABLE_EASY_POOL_KIT
        public RecycleObjectType ObjectType => RecycleObjectType.Object;

        public string PoolId { get; set; } = string.Empty;
        
        public int ObjectId { get; set; }
        
        public string Name { get; set; } = String.Empty;
        
        public float UsedTime { get; set; }
        
        public virtual void OnObjectInit(){}

        public virtual void OnObjectDeInit(){}

        public virtual void OnObjectSpawn(){}

        public virtual void OnObjectDespawn(){}

        public virtual void OnObjectUpdate(float deltaTime)
        {
            Clear();
        }
#endif
    }
}