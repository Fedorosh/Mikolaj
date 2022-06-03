using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Collisions
{
    public class Enemy : Collidable
    {
        protected override void OnCollided(DyingObject collision)
        {
            collision.LastEnemyInfo = this;
        }
    }
}

