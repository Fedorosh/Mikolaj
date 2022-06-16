using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Collisions.Collectables
{
    public class CheckpointCollectable : Collectable
    {
        protected override void OnCollided(DyingObject collision)
        {
            base.OnCollided(collision);
            RepositionController.Instance.ActualRepositionPoint = transform;
        }
    }
}

