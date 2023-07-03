using System;
using UnityEngine;

namespace EasyEvent.Demo
{
    public class Demo2_Manager : MonoBehaviour
    {
        private void Start()
        {
            EasyEventKit.Instance.Register(ExampleEventArgs.EventId, ExampleEventHandler);
            EasyEventKit.Instance.Register(ExampleEventArgs.EventId, ExampleEventHandler);
        }

        private void OnDestroy()
        {
            
        }

        private void ExampleEventHandler(object sender, EasyEventArgs eventArgs)
        {
            
        }
    }
}
