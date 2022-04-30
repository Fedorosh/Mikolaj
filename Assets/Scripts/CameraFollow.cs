using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform transformToFollow;
    public float smoothTime = 10f;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector3 startingCameraPosition = Vector3.zero;

    private void Start()
    {
        //startingCameraPosition = transform.position - transformToFollow.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,transformToFollow.position,ref startingCameraPosition,smoothTime * Time.deltaTime);
        transform.LookAt(playerTransform);
    }
}
