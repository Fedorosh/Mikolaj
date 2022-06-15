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

        private void Start()
        {
            CollidedEvent.AddListener(OnCollided);
        }

        public void InvokeCollidedEvent(DyingObject dyingObject)
        {
            CollidedEvent?.Invoke(dyingObject);
        }

        protected abstract void OnCollided(DyingObject dyingObject);
    }
}

