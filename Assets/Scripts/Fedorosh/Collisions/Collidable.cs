using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fedorosh.Collisions
{
    [RequireComponent(typeof(Collider))]
    public abstract class Collidable : MonoBehaviour
    {
        protected TriggerCollidedEvent CollidedEvent = new TriggerCollidedEvent();

        public void InvokeCollidedEvent(DyingObject dyingObject)
        {
            CollidedEvent?.Invoke(dyingObject);
        }
    }
}

