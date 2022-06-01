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

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (lastCollidedCollider == hit.collider) return;
            lastCollidedCollider = hit.collider;
            if (hit.collider.TryGetComponent(out Collidable collidable))
            {
                collidable.InvokeCollidedEvent(this);
            }
        }

    }

}
