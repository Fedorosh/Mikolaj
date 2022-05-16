using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Dying
{
    public class FallDyingTrigger : DyingTrigger
    {
        [SerializeField] private float yValueToFall;
        [SerializeField] private DyingObject objectToDie;
        public override void HandleTriggerDieEvent(TriggerDieEvent triggerDieEvent)
        {
            if (objectToDie == null) return;

            if(objectToDie.transform.position.y < yValueToFall) triggerDieEvent?.Invoke(objectToDie);
        }
    }
}

