using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Debug
{
    public class DebugChangeResolution : DebugAction
    {
        private Resolution[] resolutions;
        private int resIndex;
        protected override void Start()
        {
            resolutions = Screen.resolutions;
            resIndex = Array.IndexOf(resolutions,Screen.currentResolution);
        }

        public override void OnValueChanged(int value)
        {
            resIndex += value;
            if (resIndex >= resolutions.Length) resIndex = 0;
            if (resIndex < 0) resIndex = resolutions.Length - 1;
            Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, true);
        }

        protected override void Update()
        {

        }
    }
}

