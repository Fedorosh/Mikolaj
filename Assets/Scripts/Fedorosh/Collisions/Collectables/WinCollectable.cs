using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh.Collisions.Collectables
{
    public class WinCollectable : Collectable
    {
        private bool collidedOnce = false;
        protected override void OnCollided(DyingObject collision)
        {
            if(!collidedOnce)
            {
                GameController.Instance.ShowWinScreen();
                Cursor.lockState = CursorLockMode.None;
                collidedOnce = true;
            }
        }
    }
}
