using Fedorosh.Dying;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fedorosh.HPFolder;

namespace Fedorosh.UI
{
    public class DisplayHP : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        void Start()
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
            HPController.HPChangedTrigger.AddListener(HPChanged);
        }
        
        private void HPChanged(int HP)
        {
            textMesh.text = HP.ToString();
        }

    }
}

