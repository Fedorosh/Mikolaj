using Fedorosh.Dying;
using Fedorosh.Respawning;
using Fedorosh.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionController : MonoBehaviourSingleton<RepositionController>
{
    [SerializeField] Transform repositionObjectParent;

    [SerializeField] Transform startingPoint;

    [SerializeField] private Vector3 playerRespawnOffset = Vector3.zero;

    private Transform actualRepositionPoint;

    public Transform ActualRepositionPoint 
    { 
        get { return actualRepositionPoint; } 
        set 
        {
            actualRepositionPoint.position = value.position;
        } 
    }
    void Start()
    {
        RespawningController.TriggerRespawnEvent.AddListener(Reposition);
        actualRepositionPoint = startingPoint;
    }

    private void Reposition(DyingObject dyingObject)
    {
        repositionObjectParent.position = actualRepositionPoint.position;
        dyingObject.transform.localPosition = playerRespawnOffset;
        dyingObject.transform.localRotation = Quaternion.identity;
    }
}
