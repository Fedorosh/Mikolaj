using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedorosh.Collisions.Collectables
{
    public class PresentCollectable : Collectable
    {
        protected override void OnCollided(DyingObject collision)
        {
            base.OnCollided(collision);
            GameController.Instance.IncrementCollectedPresents(1);
        }
    }
}
