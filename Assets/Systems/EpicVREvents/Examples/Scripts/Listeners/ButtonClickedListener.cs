using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonClickedListener : MonoBehaviour
{
    public UnityEvent OnButtonClicked;
    public EpicVREvent ButtonClickedEvent;

    public GameObject RedCubePrefab;
    void Start()
    {
        ButtonClickedEvent.AddListener((x) => OnButtonClicked?.Invoke());
    }

    private void OnDestroy()
    {
        ButtonClickedEvent.RemoveListener((x) => OnButtonClicked?.Invoke());
    }

    public void SpawnCube()
    {
        Instantiate(RedCubePrefab);
    }
}
