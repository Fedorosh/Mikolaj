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
        transform.position = Vector3.Lerp(transform.position, transformToFollow.position, positionSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, transformToFollow.rotation, rotationSpeed * Time.deltaTime);
    }
}
