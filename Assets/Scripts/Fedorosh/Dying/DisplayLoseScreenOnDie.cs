using Fedorosh;
using Fedorosh.Dying;
using Fedorosh.HPFolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisplayLoseScreenOnDie : MonoBehaviour
{
    void Start()
    {
        HPController.HPChangedTrigger.AddListener(DisplayOnDie);
    }

    private void DisplayOnDie(int HP)
    {
        if (HP <= 0)
            GameController.Instance.ShowLoseScreen();
    }
}
