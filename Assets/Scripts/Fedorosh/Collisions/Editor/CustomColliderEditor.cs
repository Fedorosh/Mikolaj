using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fedorosh.Collisions
{
#if UNITY_EDITOR
    [CustomEditor(typeof(CustomColliderTrigger))]
    public class CustomColliderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            CustomColliderTrigger col = (CustomColliderTrigger)target;
            if(GUILayout.Button("FindColliders"))
            {
                if(!Application.isPlaying)
                    col.FindColliders();
            }
        }
    }
#endif
}

