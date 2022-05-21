using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDyingTrigger : DyingTrigger
{
    public override bool HandleTriggerDieEvent(out DyingObject dyingObjectRef)
    {
        dyingObjectRef = null;
        if (!CheckDyingObjectState()) return false;
        if (Input.GetKeyDown(KeyCode.F5)) { dyingObjectRef = dyingObject; return true; }
        dyingObjectRef = null;
        return false;
    }

}
