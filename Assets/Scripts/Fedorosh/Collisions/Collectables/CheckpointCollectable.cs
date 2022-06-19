using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fedorosh.Collisions.Collectables
{
    public class CheckpointCollectable : Collectable
    {
        [SerializeField]
        private Transform spawnTransform;

        protected override void Start()
        {
            base.Start();
            if(spawnTransform == null)
                spawnTransform = transform;
        }

        protected override void OnCollided(DyingObject collision)
        {
            base.OnCollided(collision);
            RepositionController.Instance.ActualRepositionPoint = spawnTransform;
        }
    }
}

