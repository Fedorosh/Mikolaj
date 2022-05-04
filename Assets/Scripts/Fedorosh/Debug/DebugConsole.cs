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
        [SerializeField] private GameObject console;
        void Start()
        {

        }

        void Update()
        {
            HandleBinders();
        }

        private void HandleBinders()
        {
            foreach (var binder in binders)
            {
                if (binder.blockWhenHidden && !console.activeSelf) continue;
                binder.HandleKeyClicked();
            }
        }
    }

    [Serializable]
    public class KeyButtonBinder
    {
        public KeyCode key;
        public Button button;
        public bool blockWhenHidden;

        public void HandleKeyClicked()
        {
            if (Input.GetKeyDown(key)) button.onClick?.Invoke();
        }
    }
}

