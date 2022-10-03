using Cinemachine;
using Fedorosh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTouchInput : MonoBehaviour
{
#if UNITY_ANDROID
    private CinemachineFreeLook cinemachine;
    private bool receiveInput = false;

    [SerializeField] private FixedTouchField touchField;
    void Start()
    {
        cinemachine = GetComponent<CinemachineFreeLook>();
        cinemachine.m_XAxis.m_InputAxisName = string.Empty;
        cinemachine.m_YAxis.m_InputAxisName = string.Empty;
    }

    void Update()
    {
        cinemachine.m_XAxis.m_InputAxisValue = touchField.TouchDist.normalized.x;
        cinemachine.m_YAxis.m_InputAxisValue = touchField.TouchDist.normalized.y;
    }
#endif
}
