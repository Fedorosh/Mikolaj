using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Dying
{
    public class EnemyHitDyingTrigger : DyingTrigger
    {
        public override bool HandleTriggerDieEvent(out DyingObject dyingObjectRef)
        {
            dyingObjectRef = null;
            if (!CheckDyingObjectState()) return false;
            if(dyingObject.LastEnemyInfo != null)
            {
                dyingObjectRef = dyingObject;
                dyingObject.LastEnemyInfo = null;
                return true;
            }
            return false;
        }
    }
}

