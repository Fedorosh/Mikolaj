using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Debug
{
    public class DebugAction : MonoBehaviour
    {
        protected virtual void Start() { }
        protected virtual void Update() { }
        public virtual void OnValueChanged(int value)
        {
        }
        public virtual void OnButtonClicked()
        {
        }
    }
}

