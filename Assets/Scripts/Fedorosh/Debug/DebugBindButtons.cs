using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh.Debug
{
    public class DebugBindButtons : MonoBehaviour
    {
        private DebugAction debugAction;

        public IncreaseDecreaseButton increaseDecreaseButtons;
        public Button standardButton;

        void Start()
        {
            debugAction = GetComponent<DebugAction>();
            if (standardButton != null)
                standardButton.onClick.AddListener(() => debugAction.OnButtonClicked());

            if (increaseDecreaseButtons.increaseButton == null || increaseDecreaseButtons.decreaseButton == null) return;

            increaseDecreaseButtons.increaseButton.onClick.AddListener(() => debugAction.OnValueChanged(1));
            increaseDecreaseButtons.decreaseButton.onClick.AddListener(() => debugAction.OnValueChanged(-1));

        }

        [Serializable]
        public class IncreaseDecreaseButton
        {
            public Button decreaseButton;
            public Button increaseButton;
        }
    }
}

