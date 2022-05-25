using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedorosh.Respawning
{
    public class RespawnAfterDieTrigger : RespawningTrigger
    {
        public override bool HandleTriggerRespawnEvent(out DyingObject dyingObjectRef)
        {
            dyingObjectRef = null;
            return true;
        }
    }
}
