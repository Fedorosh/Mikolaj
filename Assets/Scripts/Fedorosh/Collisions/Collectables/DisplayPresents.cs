using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Fedorosh.Collisions.Collectables
{
    public class DisplayPresents : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        void Start()
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
            GameController.PresentCollectedEvent.AddListener(PresentsChanged);
        }

        private void PresentsChanged(int i)
        {
            textMesh.text = GameController.Instance.PresentsCollected.ToString();
        }
    }
}
