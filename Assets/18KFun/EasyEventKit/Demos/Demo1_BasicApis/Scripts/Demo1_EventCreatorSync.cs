using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EasyEvent.Demo
{
    public class Demo1_EventCreatorSync : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(SendChangeTextEvent());
            StartCoroutine(SendChangeColorEvent());
        }

        private IEnumerator SendChangeTextEvent()
        {
            yield return new WaitForSeconds(Random.Range(1f, 4f));

            var changeTextEvent = Demo1_ChangeTextEventArgs.CreateEvent(Random.Range(100000, 999999).ToString());
  
            EasyEventKit.Instance.DispatchEvent(gameObject, changeTextEvent);

            StartCoroutine(SendChangeTextEvent());
        }
        
        private IEnumerator SendChangeColorEvent()
        {
            yield return new WaitForSeconds(Random.Range(1f, 4f));

            var randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.5f, 1f));
            
            var changeColorEvent = Demo1_ChangeColorEventArgs.CreateEvent(randomColor);
            
            EasyEventKit.Instance.DispatchEvent(gameObject, changeColorEvent);

            StartCoroutine(SendChangeColorEvent());
        }
    }
}