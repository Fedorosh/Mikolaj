using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Fedorosh.Dying
{
    public class DyingController : MonoBehaviour
    {
        public static TriggerDieEvent TriggerDieEvent;

        private bool diedAlready = false;

        public DyingTrigger[] DieTriggers;

        private void Start()
        {
            TriggerDieEvent.AddListener(DieEventTriggered);
        }

        private void DieEventTriggered(DyingObject obj)
        {
            diedAlready = true;
        }

        private void Update()
        {
            foreach(var trigger in DieTriggers) 
                if(!diedAlready)
                    trigger.HandleTriggerDieEvent(TriggerDieEvent);
        }
    }
}

