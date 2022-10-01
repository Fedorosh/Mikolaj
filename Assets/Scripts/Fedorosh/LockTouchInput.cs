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
    void Start()
    {
        cinemachine = GetComponent<CinemachineFreeLook>();
        cinemachine.m_XAxis.m_InputAxisName = string.Empty;
        cinemachine.m_YAxis.m_InputAxisName = string.Empty;
    }

    void Update()
    {
        if(PlayerMovement.input.GetTouchDown()) receiveInput = true;
        if(PlayerMovement.input.GetTouchUpAnywhere()) receiveInput = false;

        if (receiveInput)
        {
            cinemachine.m_XAxis.m_InputAxisValue = Input.GetAxisRaw("Mouse X");
            cinemachine.m_YAxis.m_InputAxisValue = Input.GetAxisRaw("Mouse Y");
        }
        else cinemachine.m_XAxis.m_InputAxisValue = 0f;
    }
#endif
}
