using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh.Debug
{
    public class ResolutionUpdater : MonoBehaviour
    {
        private Text text;
        Resolution screenRes;
        void Start()
        {
            text = GetComponent<Text>();
            if (text != null)
                UpdateResolution();
        }

        void Update()
        {
            if (text == null) return;
            if (screenRes.ToString() != Screen.currentResolution.ToString()) UpdateResolution();
        }

        private void UpdateResolution()
        {
            screenRes = Screen.currentResolution;
            string newRes = screenRes.ToString();
            text.text = newRes.Substring(0, newRes.Length - 7);
        }
    }
}

