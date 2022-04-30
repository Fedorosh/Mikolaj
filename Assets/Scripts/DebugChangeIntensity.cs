using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugChangeIntensity : DebugAction
{
    [SerializeField] private Text valueText;
    [SerializeField] private CameraFollow cameraScript;
    [Range(1,100)]
    public int stepMultiplier = 1;
    public int maxValue = 10000;
    public void OnValueChanged(int value)
    {
        int valueInt;
        if (!int.TryParse(valueText.text, out valueInt)) return;
        valueInt += value * stepMultiplier;
        if (valueInt <= 0) valueInt = 1;
        if (valueInt > maxValue) valueInt = maxValue;
        cameraScript.smoothTime = valueInt;
        valueText.text = valueInt.ToString(); 
    }
}
