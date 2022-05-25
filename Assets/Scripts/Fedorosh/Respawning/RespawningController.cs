using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fedorosh;

namespace Fedorosh.Respawning
{
    public class RespawningController : MonoBehaviour
    {
        public static TriggerRespawnEvent TriggerRespawnEvent = new TriggerRespawnEvent();

        public RespawningTrigger[] respawnTriggers;

        void Update()
        {
            HandleTriggers();
        }

        public void HandleTriggers()
        {
            foreach (var trigger in respawnTriggers)
                if (trigger.HandleTriggerRespawnEvent(out DyingObject dyingObject))
                {
                    TriggerRespawnEvent?.Invoke(dyingObject);
                    dyingObject.State = DyingObjectState.Alive;
                }
        }
    }
}

