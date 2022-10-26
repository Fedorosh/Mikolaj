using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTouchedListener : MonoBehaviour
{
    public EpicVREvent CubeTouchedGroundEvent;
    public Material greenMaterial;

    private void Start()
    {
        CubeTouchedGroundEvent.AddListener((x) => OnCubeTouchedGround((MeshRenderer)x));
    }

    private void OnDestroy()
    {
        CubeTouchedGroundEvent.RemoveListener((x) => OnCubeTouchedGround((MeshRenderer)x));
    }

    public void OnCubeTouchedGround(MeshRenderer renderer)
    {
        renderer.materials = new Material[] { greenMaterial };
    }
}
