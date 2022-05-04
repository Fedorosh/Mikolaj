using System;
using UnityEngine;

namespace Fedorosh.Debug
{
    public class DebugShowHideConsole : DebugAction
    {
        [SerializeField] private GameObject console;
        public override void OnButtonClicked()
        {
            bool show = !console.activeSelf;
            console.SetActive(show);
        }
    }
}
