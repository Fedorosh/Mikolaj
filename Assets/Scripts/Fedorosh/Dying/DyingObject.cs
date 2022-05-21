using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fedorosh.Dying
{
    public enum DyingObjectState
    {
        Dead,
        Alive
    }
    public class DyingObject : MonoBehaviour
    {
        public DyingObjectState State;
    }
}
