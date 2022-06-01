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
        private void Start()
        {
            CollidedEvent.AddListener(OnCollided);
        }
        private void OnCollided(DyingObject collision)
        {
            Destroy(gameObject);
            //UnityEngine.Debug.Log("Collided");
        }
    }
}
