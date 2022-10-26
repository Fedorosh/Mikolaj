using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventData",menuName = "ScriptableObjects/Event")]
public class EpicVREvent : ScriptableObject
{
    private UnityEvent<object> _event = new UnityEvent<object>();

    /// <summary>
    /// Adds action to the event, which will be triggered at event invoke.
    /// In most cases, for example UnityEvent, you need to use lambda expression and make sure that you cast the object type as desired type in added listener.
    /// </summary>
    /// <param name="_event">UnityAction type with object parameter which can be casted as specific type</param>
    public void AddListener(UnityAction<object> _event)
    {
        this._event.AddListener(_event);
    }
    /// <summary>
    /// Removes action from the event.
    /// </summary>
    /// <param name="_event">UnityAction type with object parameter which can be casted as specific type</param>
    public void RemoveListener(UnityAction<object> _event)
    {
        this._event.RemoveListener(_event);
    }
    /// <summary>
    /// Invokes this event and triggers all added listeners. You can just pass any type which derives object type, but make sure that you cast the desired type properly when adding a listener.
    /// </summary>
    /// <param name="obj"></param>
    public void InvokeEvent(object obj)
    {
        _event?.Invoke(obj);
    }

    /// <summary>
    /// Invokes this event and triggers all added listeners without passing any value. Useful when using UnityEditor events which don't require specified parameter.
    /// </summary>
    public void InvokeNullEvent()
    {
        _event?.Invoke(null);
    }
}
