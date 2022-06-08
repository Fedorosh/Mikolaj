using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformSettings", menuName = "ScriptableObjects/PlatformSettings")]
public class PlatformSettingsObject : ScriptableObject
{
    public float turnSensitivity;
    public float cameraSmoothTime;
}
