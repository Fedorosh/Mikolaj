using Fedorosh.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Fedorosh.Dying
{
    public class DyingController : MonoBehaviour
    {
        public static TriggerDieEvent TriggerDieEvent = new TriggerDieEvent();

        public DyingTrigger[] dieTriggers;

        private void Update()
        {
            HandleTriggers();
        }

        private void HandleTriggers()
        {
            foreach (var trigger in dieTriggers)
                if (trigger.HandleTriggerDieEvent(out DyingObject dyingObject))
                {
                    TriggerDieEvent?.Invoke(dyingObject);
                    dyingObject.State = DyingObjectState.Dead;
                }
        }
    }
}

