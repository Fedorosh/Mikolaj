using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestDying : MonoBehaviour
{
    private void Start()
    {
        DyingController.TriggerDieEvent.AddListener(OnDie);
    }
    public void OnDie(DyingObject dyingObject)
    {
        Debug.Log($"{dyingObject.name} died");
    }
}
