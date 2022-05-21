using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Fedorosh.Dying
{
    public class FallDyingTrigger : DyingTrigger
    {
        [SerializeField] private float yValueToFall;
        public override bool HandleTriggerDieEvent(out DyingObject dyingObjectRef)
        {
            dyingObjectRef = null;
            if (!CheckDyingObjectState()) return false;
            if (dyingObject.transform.position.y < yValueToFall) { dyingObjectRef = dyingObject; return true; }
            
            return false;
        }
    }
}

