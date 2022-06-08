using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform transformToFollow;
        public float smoothTime = 10f;
        //[SerializeField] private float rotationSpeed = 10f;

        [SerializeField] private PlatformSettingsObject androidSettings;
        [SerializeField] private PlatformSettingsObject pcSettings;

        private Vector3 startingCameraPosition = Vector3.zero;

        private void Start()
        {
#if !UNITY_ANDROID
            smoothTime = pcSettings.cameraSmoothTime;
#else
            smoothTime = androidSetting.cameraSmoothTime;
#endif
            //startingCameraPosition = transform.position - transformToFollow.position;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, transformToFollow.position, ref startingCameraPosition, smoothTime * Time.deltaTime);
            transform.LookAt(playerTransform);
        }
    }
}

