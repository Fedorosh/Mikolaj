using Fedorosh.Dying;
using Fedorosh.HPFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedorosh.Collisions.Collectables
{
    public class HPCollectable : Collectable
    {
        protected override void OnCollided(DyingObject collision)
        {
            base.OnCollided(collision);
            collision.ObjectHP++;
            HPController.InvokeHPChangedTrigger(collision.ObjectHP);
        }
    }
}
