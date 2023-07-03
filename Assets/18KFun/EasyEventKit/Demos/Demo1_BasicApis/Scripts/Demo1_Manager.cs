using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyEvent.Demo
{
    public class Demo1_Manager : MonoBehaviour
    {
        public GameObject EventCreatorSync;
        public GameObject EventCreatorAsync;

        public Text TextAll;
        public Text TextSync;
        public Text TextAsync;

        public Button ButtonAll;
        public Button ButtonSync;
        public Button ButtonAsync;

        private bool _enableListenAll;
        private bool _enableListenSync;
        private bool _enableListenAsync;

        public void Awake()
        {
            EasyEventKit.Instance.Register(Demo1_ChangeTextEventArgs.EventId, ChangeTextHandlerDealAll);
            EasyEventKit.Instance.Register(Demo1_ChangeColorEventArgs.EventId, ChangeColorHandlerDealAll);
            
            EasyEventKit.Instance.Register(Demo1_ChangeTextEventArgs.EventId, ChangeTextHandlerDealSyncObj);
            EasyEventKit.Instance.Register(Demo1_ChangeColorEventArgs.EventId, ChangeColorHandlerDealSync);

            EasyEventKit.Instance.Register(Demo1_ChangeTextEventArgs.EventId, ChangeTextHandlerDealAsyncObj);
            EasyEventKit.Instance.Register(Demo1_ChangeColorEventArgs.EventId, ChangeColorHandlerDealAsync);

            _enableListenAll = true;
            _enableListenSync = true;
            _enableListenSync = true;
        }

        public void OnDestroy()
        {
            if (_enableListenAll)
            {
                EasyEventKit.Instance.Unregister(Demo1_ChangeTextEventArgs.EventId, ChangeTextHandlerDealAll);
                EasyEventKit.Instance.Unregister(Demo1_ChangeColorEventArgs.EventId, ChangeColorHandlerDealAll);
            }

            if (_enableListenSync)
            {
                EasyEventKit.Instance.Unregister(Demo1_ChangeTextEventArgs.EventId, ChangeTextHandlerDealSyncObj);
                EasyEventKit.Instance.Unregister(Demo1_ChangeColorEventArgs.EventId, ChangeColorHandlerDealSync);
            }

            if (_enableListenAsync)
            {
                EasyEventKit.Instance.Unregister(Demo1_ChangeTextEventArgs.EventId, ChangeTextHandlerDealAsyncObj);
                EasyEventKit.Instance.Unregister(Demo1_ChangeColorEventArgs.EventId, ChangeColorHandlerDealAsync);                
            }
        }

        private void ChangeTextHandlerDealAll(object sender, EasyEventArgs e)
        {
            if (e is Demo1_ChangeTextEventArgs changeTextEventArgs)
            {
                TextAll.text = changeTextEventArgs.TextStr;
            }
        }
        
        private void ChangeColorHandlerDealAll(object sender, EasyEventArgs e)
        {
            if (e is Demo1_ChangeColorEventArgs changeColorEventArgs)
            {
                TextAll.color = changeColorEventArgs.TextColor;
            }
        }
        
        private void ChangeTextHandlerDealSyncObj(object sender, EasyEventArgs e)
        {
            if ((GameObject)sender != EventCreatorSync)
            {
                return;
            }

            if (e is Demo1_ChangeTextEventArgs changeTextEventArgs)
            {
                TextSync.text = changeTextEventArgs.TextStr;
            }
        }
        
        
        private void ChangeColorHandlerDealSync(object sender, EasyEventArgs e)
        {
            if ((GameObject)sender != EventCreatorSync)
            {
                return;
            }
            
            if (e is Demo1_ChangeColorEventArgs changeColorEventArgs)
            {
                TextSync.color = changeColorEventArgs.TextColor;
            }
        }
        
        private void ChangeTextHandlerDealAsyncObj(object sender, EasyEventArgs e)
        {
            if ((GameObject)sender != EventCreatorAsync)
            {
                return;
            }
            
            if (e is Demo1_ChangeTextEventArgs changeTextEventArgs)
            {
                TextAsync.text = changeTextEventArgs.TextStr;
            }
        }
        
        private void ChangeColorHandlerDealAsync(object sender, EasyEventArgs e)
        {
            if ((GameObject)sender != EventCreatorAsync)
            {
                return;
            }
            
            if (e is Demo1_ChangeColorEventArgs changeColorEventArgs)
            {
                TextAsync.color = changeColorEventArgs.TextColor;
            }
        }
    }
}