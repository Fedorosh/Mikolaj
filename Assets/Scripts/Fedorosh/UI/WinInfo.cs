using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinInfo : MonoBehaviour
{
    [SerializeField] private string regularWin;
    [SerializeField] private string platinumWin;

    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject platinum;

    public int MaxScore { get; set; }
    public int Score { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }

    private void OnEnable()
    {
        if (Score == MaxScore && HP == MaxHP)
        {
            if(platinum != null)
                platinum.SetActive(true);
            winText.text = platinumWin;
        }
        else
        {
            winText.text = regularWin;
        }

        score.text = string.Format("{0}/{1}",Score,MaxScore);
    }

}
