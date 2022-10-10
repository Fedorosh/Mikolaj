using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    //const float UPDATER = .2f;

    //private Text tmpText;
    //private int fps;
    //private float currentUpdate = 0;

    //private void Start()
    //{
    //    tmpText = GetComponent<Text>();
    //}

    //private void Update()
    //{
    //    currentUpdate += Time.deltaTime;

    //    if (currentUpdate >= UPDATER)
    //    {
    //        currentUpdate -= UPDATER;

    //        fps = Mathf.RoundToInt(1f / Time.deltaTime);
    //        tmpText.text = $"{fps} FPS";
    //    }

    //}
    public float fps;
    private Text fpsText;

    private void Start()
    {
        fpsText = GetComponent<Text>();
        InvokeRepeating(nameof(GetFPS), 1, 0.5f);
    }


    private void GetFPS()
    {
        fps = (int)(1f / Time.deltaTime);
        fpsText.text = fps + " fps";
    }
}
