using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fedorosh.Collisions
{
    [RequireComponent(typeof(CustomColliderTrigger))]
    public abstract class Collidable : MonoBehaviour
    {
        protected TriggerCollidedEvent CollidedEvent = new TriggerCollidedEvent();
        protected TriggerUncollidedEvent UncollidedEvent = new TriggerUncollidedEvent();

        protected virtual void Start()
        {
            CollidedEvent.AddListener(OnCollided);
            UncollidedEvent.AddListener(OnUncollided);
        }

        public void InvokeCollidedEvent(DyingObject dyingObject)
        {
            CollidedEvent?.Invoke(dyingObject);
        }

        public void InvokeUncollidedEvent(DyingObject dyingObject)
        {
            UncollidedEvent?.Invoke(dyingObject);
        }

        protected abstract void OnCollided(DyingObject dyingObject);
        protected abstract void OnUncollided(DyingObject dyingObject);
    }
}

