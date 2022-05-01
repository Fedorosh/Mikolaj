using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh.Debug
{
    public class DebugConsole : MonoBehaviour
    {
        public List<KeyButtonBinder> binders;
        void Start()
        {

        }

        void Update()
        {
            HandleBinders();
        }

        private void HandleBinders()
        {
            foreach (var binder in binders) binder.HandleKeyClicked();
        }
    }

    [Serializable]
    public class KeyButtonBinder
    {
        public KeyCode key;
        public Button button;

        public void HandleKeyClicked()
        {
            if (Input.GetKeyDown(key)) button.onClick?.Invoke();
        }
    }
}

