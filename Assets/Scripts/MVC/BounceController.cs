using MVC.Application;
using UnityEngine;
using UnityEngine.XR;

public class BounceController : BounceElement
{
    private BaseController[] controllers;
    public BaseController[] Controllers => controllers;
    private void Awake()
    {
        controllers = GetComponentsInChildren<BaseController>();
    }
}