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
        bool isPlatinum = Score == MaxScore && HP == MaxHP;

        if (platinum != null)
            platinum.SetActive(isPlatinum);

        winText.text = isPlatinum ? platinumWin : regularWin;

        score.text = string.Format("{0}/{1}",Score,MaxScore);
    }

}
