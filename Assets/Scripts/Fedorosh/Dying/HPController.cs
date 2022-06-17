using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Dying
{
    public class HPController : MonoBehaviour
    {
        private void Start()
        {
            DyingController.TriggerDieEvent.AddListener(TakeHPOnDie);
        }
        private void TakeHPOnDie(DyingObject dyingObject)
        {
            dyingObject.ObjectHP--;
        }
    }
}

