using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Fedorosh.Collisions
{
    public class CustomColliderTrigger : MonoBehaviour
    {
        public List<Collider> colliders;

        private List<CustomTrigger> triggers = new List<CustomTrigger>();

        private CustomOnTriggerEnter OnTriggerEnter = new CustomOnTriggerEnter();

        private void Start()
        {
            colliders.ForEach(x =>
            {
                CustomTrigger trigger = x.gameObject.AddComponent<CustomTrigger>();
                trigger._customColliderTrigger = this;
                triggers.Add(trigger);
            });
            OnTriggerEnter.AddListener(OnCustomTriggerEnter);
        }

        public void InvokeOnTriggerEnter(Collider other)
        {
            OnTriggerEnter?.Invoke(other);
        }

        private void OnCustomTriggerEnter(Collider other)
        {
            triggers.ForEach(x => x.Triggered = true);

            //do something
        }

        public void FindColliders()
        {
            colliders = new List<Collider>();
            Collider[] cols = GetComponentsInChildren<Collider>(true);
            colliders.AddRange(cols);
            colliders.ForEach(x => x.isTrigger = true);
        }
    }
}

