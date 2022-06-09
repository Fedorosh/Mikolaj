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

        public float valueStep = 1f;

        void Start()
        {
            debugAction = GetComponent<DebugAction>();
            if (standardButton != null)
                standardButton.onClick.AddListener(() => debugAction.OnButtonClicked());

            if (increaseDecreaseButtons.increaseButton == null || increaseDecreaseButtons.decreaseButton == null) return;

            increaseDecreaseButtons.increaseButton.onClick.AddListener(() => debugAction.OnValueChanged(valueStep));
            increaseDecreaseButtons.decreaseButton.onClick.AddListener(() => debugAction.OnValueChanged(-valueStep));

        }

        [Serializable]
        public class IncreaseDecreaseButton
        {
            public Button decreaseButton;
            public Button increaseButton;
        }
    }
}

