using Fedorosh.Dying;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestDying : MonoBehaviour
{
    private void Start()
    {
        try
        {
            if (DyingController.TriggerDieEvent == null) throw new NullReferenceException("TriggerDieEvent faktycznie jest nullem.");
            DyingController.TriggerDieEvent.AddListener(OnDie);

        }
        catch (NullReferenceException e)
        {
            UnityEngine.Debug.LogError(e.Message);
        }
    }
    public void OnDie(DyingObject dyingObject)
    {
        Debug.Log($"{dyingObject.name} died");
    }
}
