using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Fedorosh.Dying
{
    public abstract class DyingTrigger : MonoBehaviour
    {
        [SerializeField] protected DyingObject dyingObject;
        protected bool CheckDyingObjectState()
        {
            if (dyingObject == null) return false;
            if (dyingObject.State == DyingObjectState.Dead) return false;
            return true;
        }
        public abstract bool HandleTriggerDieEvent(out DyingObject dyingObjectRef);
    }
}
