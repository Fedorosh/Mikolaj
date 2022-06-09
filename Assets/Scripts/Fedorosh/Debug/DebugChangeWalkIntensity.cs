using System;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh.Debug
{
    public class DebugChangeWalkIntensity : DebugAction
    {
        [SerializeField] private Text valueText;
        [SerializeField] private PlayerMovement playerScript;
        [Range(1, 100)]
        public int stepMultiplier = 1;
        public int maxValue = 10000;
        public override void OnButtonClicked()
        {
            int valueInt;
            if (!int.TryParse(valueText.text, out valueInt)) return;
            playerScript.rotateSpeed = valueInt;
        }

        public override void OnValueChanged(float value)
        {
            float valueFloat;
            if (!float.TryParse(valueText.text, out valueFloat)) return;
            valueFloat += value * stepMultiplier;
            if (valueFloat <= 0) valueFloat = 1;
            if (valueFloat > maxValue) valueFloat = maxValue;
            playerScript.speed = valueFloat;
            valueText.text = valueFloat.ToString();
        }
    }
}
