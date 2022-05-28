using Fedorosh.Dying;
using Fedorosh.Respawning;
using Fedorosh.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionController : MonoBehaviourSingleton<RepositionController>
{
    [SerializeField] Transform repositionObjectParent;

    [SerializeField] /*temporary serializefield*/ private Transform actualRepositionPoint;

    [SerializeField] private Vector3 playerRespawnOffset = Vector3.zero;

    //TO USE WHEN I MAKE COLLECTABLES
    public Transform ActualRepositionPoint { get { return actualRepositionPoint; } set { actualRepositionPoint = value; } }
    void Start()
    {
        RespawningController.TriggerRespawnEvent.AddListener(Reposition);
    }

    private void Reposition(DyingObject dyingObject)
    {
        dyingObject.transform.localPosition = playerRespawnOffset;
        dyingObject.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
