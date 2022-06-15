using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fedorosh.Collisions
{
    public class CustomTrigger : MonoBehaviour
    {
        public bool Triggered { get; set; } = false;

        public CustomColliderTrigger _customColliderTrigger { get; set; } = null;

        private void OnTriggerEnter(Collider other)
        {
            if (!Triggered) _customColliderTrigger.InvokeOnTriggerEnter(other);
        }
    }
}

