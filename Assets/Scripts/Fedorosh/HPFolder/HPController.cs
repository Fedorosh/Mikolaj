using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh.HPFolder
{
    public class HPController : MonoBehaviour
    {
        public static HPChangedTrigger HPChangedTrigger = new HPChangedTrigger();

        public static void InvokeHPChangedTrigger(int HP)
        {
            HPChangedTrigger.Invoke(HP);
        }
    }
}
