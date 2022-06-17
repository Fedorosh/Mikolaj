using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh.Respawning
{
    public class RespawnAfterDieTrigger : RespawningTrigger
    {
        public float timeToRespawn = 0f;
        private float timeLeftToRespawn;
        private void Start()
        {
            timeLeftToRespawn = timeToRespawn;
        }
        public override bool HandleTriggerRespawnEvent(out DyingObject dyingObjectRef)
        {
            dyingObjectRef = null;
            if(!CheckRespawningObjectState()) return false;
            if (dyingObject.ObjectHP <= 0) return false;
            timeLeftToRespawn -= Time.deltaTime;
            if(timeLeftToRespawn <= 0f)
            {
                timeLeftToRespawn = timeToRespawn;
                dyingObjectRef = dyingObject;
                return true;
            }
            return false;
        }
    }
}
