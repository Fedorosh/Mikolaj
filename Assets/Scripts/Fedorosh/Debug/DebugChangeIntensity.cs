using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh.Debug
{
    public class DebugChangeIntensity : DebugAction
    {
        [SerializeField] private Text valueText;
        [SerializeField] private CameraFollow cameraScript;
        [Range(1, 100)]
        public int stepMultiplier = 1;
        public int maxValue = 10000;
        protected override void Start()
        {
            int valueInt;
            if (!int.TryParse(valueText.text, out valueInt)) return;
            cameraScript.smoothTime = valueInt;
        }
        public override void OnValueChanged(float value)
        {
            float valuefloat;
            if (!float.TryParse(valueText.text, out valuefloat)) return;
            valuefloat += value * stepMultiplier;
            if (valuefloat <= 0) valuefloat = 1;
            if (valuefloat > maxValue) valuefloat = maxValue;
            cameraScript.smoothTime = valuefloat;
            valueText.text = valuefloat.ToString();
        }
    }
}

