using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Debug
{
    public abstract class DebugAction : MonoBehaviour
    {
        protected virtual void Start() { }
        protected virtual void Update() { }
        public virtual void OnButtonClicked()
        {
        }
        public virtual void OnValueChanged(float value)
        {
        }
    }
}

