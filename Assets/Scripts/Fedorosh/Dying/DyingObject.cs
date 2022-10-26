using Fedorosh.Collisions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Dying
{
    public enum DyingObjectState
    {
        Dead,
        Alive
    }
    public class DyingObject : MonoBehaviour
    {
        public DyingObjectState State;

        public int ObjectHP = 3;

        public int ObjectMaxHP = 5;

        [Header("Optional references")]
        public CharacterController CharacterController;

        private Collider lastCollidedCollider = null;

        public Enemy LastEnemyInfo { get; set; } = null;

        private void OnTriggerEnter(Collider hit)
        {
            if (hit.TryGetComponent(out CustomTrigger trigger))
            {
                Collidable collidable = trigger._customColliderTrigger.GetComponent<Collidable>();
                collidable.InvokeCollidedEvent(this);
            }
        }

        private void OnTriggerExit(Collider hit)
        {
            if (hit.TryGetComponent(out CustomTrigger trigger))
            {
                Collidable collidable = trigger._customColliderTrigger.GetComponent<Collidable>();
                collidable.InvokeUncollidedEvent(this);
            }
        }
    }

}
