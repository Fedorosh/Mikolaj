using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    const float UPDATER = .2f;

    private Text tmpText;
    private int fps;
    private float currentUpdate = 0;

    private void Start()
    {
        tmpText = GetComponent<Text>();
    }

    private void Update()
    {
        currentUpdate += Time.unscaledDeltaTime;

        if (currentUpdate >= UPDATER)
        {
            currentUpdate -= UPDATER;

            fps = Mathf.RoundToInt(1f / Time.unscaledDeltaTime);
            tmpText.text = $"{fps} FPS";
        }

    }
}
