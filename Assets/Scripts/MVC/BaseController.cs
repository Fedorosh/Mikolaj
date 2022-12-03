using MVC.Application;
using UnityEngine;

public abstract class BaseController : BounceElement
{
    public abstract void OnNotification(string p_event_path, Object p_target, params object[] p_data);
}
