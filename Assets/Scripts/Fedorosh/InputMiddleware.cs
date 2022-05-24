using Fedorosh.Dying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh
{
    public class InputMiddleware : MonoBehaviour
    {
        [SerializeField] private DyingObject dyingObject;
        public float GetAxis(string axis)
        {
            if (dyingObject.State == DyingObjectState.Dead) return 0f;
            return Input.GetAxis(axis);
        }

        public bool GetKey(KeyCode key)
        {
            if(dyingObject.State == DyingObjectState.Dead) return false;
            return Input.GetKey(key);
        }

        public bool GetButtonDown(string button)
        {
            if (dyingObject.State == DyingObjectState.Dead) return false;
            return Input.GetButtonDown(button);
        }
        public bool GetKeyDown(KeyCode key)
        {
            if (dyingObject.State == DyingObjectState.Dead) return false;
            return Input.GetKeyDown(key);
        }
    }
}
