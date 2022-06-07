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

        [Header("Optional references")]
        public CharacterController CharacterController;

        private Collider lastCollidedCollider = null;

        public Enemy LastEnemyInfo { get; set; } = null;

        private void OnTriggerEnter(Collider hit)
        {
            if (hit.TryGetComponent(out Collidable collidable))
            {
                collidable.InvokeCollidedEvent(this);
            }
        }
    }

}
