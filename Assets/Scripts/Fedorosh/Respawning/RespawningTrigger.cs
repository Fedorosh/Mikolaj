using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh.Respawning
{
    public abstract class RespawningTrigger : MonoBehaviour
    {
        [SerializeField] protected DyingObject dyingObject;
        protected bool CheckRespawningObjectState()
        {
            if (dyingObject == null) return false;
            if (dyingObject.State == DyingObjectState.Alive) return false;
            return true;
        }
        public abstract bool HandleTriggerRespawnEvent(out DyingObject dyingObjectRef);
    }
}
