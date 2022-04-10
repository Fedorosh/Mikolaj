using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private float positionSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;

    private Vector3 startingCameraPosition;

    private void Start()
    {
        startingCameraPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = transformToFollow.position + startingCameraPosition;
        transform.position = Vector3.Lerp(transform.position, newPosition, positionSpeed * Time.deltaTime);
        //transform.rotation = transformToFollow.rotation;
    }
}
