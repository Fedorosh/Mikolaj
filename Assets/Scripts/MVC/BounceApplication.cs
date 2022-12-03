using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace MVC.Application
{
    public class BounceElement : MonoBehaviour
    {
        public BounceApplication app
        {
            get
            {
                return BounceApplication.instance;
            }
        }
    }

    public sealed class BounceApplication : MonoBehaviour
    {
        internal static BounceApplication instance;
        // Reference to the root instances of the MVC.
        public BounceModel model;
        public BounceView view;
        public BounceController controller;
        // Iterates all Controllers and delegates the notification data
        // This method can easily be found because every class is “BounceElement” and has an “app” 
        // instance.

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else Destroy(gameObject);
        }

        public void Notify(string p_event_path, Object p_target, params object[] p_data)
        {
            foreach (BaseController c in controller.Controllers)
            {
                c.OnNotification(p_event_path, p_target, p_data);
            }
        }
    }
}
