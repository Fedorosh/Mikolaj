using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeCubeTouched : MonoBehaviour
{
    public EpicVREvent CubeTouchedGroundEvent;
    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer mr = collision.gameObject.GetComponent<MeshRenderer>();
        CubeTouchedGroundEvent.InvokeEvent(mr);
    }
}
