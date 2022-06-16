using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh.Collisions
{
    public class Collectable : Collidable
    {
        protected override void OnCollided(DyingObject collision)
        {
            Destroy(gameObject);
        }
    }
}
