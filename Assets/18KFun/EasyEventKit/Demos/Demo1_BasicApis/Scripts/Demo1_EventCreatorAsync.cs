using System;
using System.Threading;
using UnityEngine;
using Random = System.Random;

namespace EasyEvent.Demo
{
    public class Demo1_EventCreatorAsync : MonoBehaviour
    {
        private Random _random = new Random();
        
        private GameObject _gameObject = null;
        
        public void Start()
        {
            Debug.Log($"Demo1 == Thread in Main: {Thread.CurrentThread.ManagedThreadId.ToString()}");

            var changeTextThread = new Thread(ThreadChangeText);
            changeTextThread.Start();

            var changeColorThread = new Thread(ThreadChangeColor);
            changeColorThread.Start();

            //To use in threads not main
            _gameObject = gameObject;
        }

        private void ThreadChangeText()
        {
            Debug.Log($"Demo1 == Thread in ThreadChangeText: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            while (true)
            {
                Thread.Sleep(_random.Next(1000,3000));
            
                var changeTextEvent = Demo1_ChangeTextEventArgs.CreateEvent(_random.Next(100000, 999999).ToString());
  
                EasyEventKit.Instance.DispatchEventAsync(_gameObject, changeTextEvent);
            }
        }
        
        private void ThreadChangeColor()
        {
            Debug.Log($"Demo1 == Thread in ThreadChangeColor: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            while (true)
            {
                Thread.Sleep(_random.Next(1000, 3000));
                
                var randomColor = new Color(_random.Next(0, 100) / 100f, _random.Next(0, 100) / 100f, _random.Next(0, 100) / 100f, _random.Next(50, 100) / 100f);
            
                var changeColorEvent = Demo1_ChangeColorEventArgs.CreateEvent(randomColor);
            
                EasyEventKit.Instance.DispatchEventAsync(_gameObject, changeColorEvent);
            }
        }
    }
}
