using UnityEngine;

namespace EasyEvent
{
    [DefaultExecutionOrder(-600)]
    public class EasyEventWorker : MonoBehaviour
    {
        public void Update()
        {
            EasyEventKit.Instance.UpdateKit(Time.deltaTime, Time.unscaledDeltaTime);
        }
    }
}