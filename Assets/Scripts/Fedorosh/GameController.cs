using Fedorosh.Collisions.Collectables;
using Fedorosh.Dying;
using Fedorosh.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fedorosh
{
    public class GameController : MonoBehaviourSingleton<GameController>
    {
        [SerializeField] private int maxPresents = 1;
        private int presentsCollected;

        [SerializeField] private Player playerMovement;
        [SerializeField] private WinInfo winUI;
        [SerializeField] private WinInfo loseUI;

        private AudioController audioController;

        public static PresentCollectedEvent PresentCollectedEvent = new PresentCollectedEvent();

        public int PresentsCollected => presentsCollected;
        public static AudioController AudioController => Instance.audioController;

        private void Start()
        {
            audioController = GetComponent<AudioController>();

            QualitySettings.vSyncCount = 2;
        }

        public void ShowWinScreen(DyingObject obj)
        {
            playerMovement.enabled = false;
            winUI.Score = presentsCollected;
            winUI.MaxScore = maxPresents;
            winUI.HP = obj.ObjectHP;
            winUI.MaxHP = obj.ObjectMaxHP;
            winUI.gameObject.SetActive(true);
            audioController.PlayWinSound();
        }

        public void ShowLoseScreen()
        {
            playerMovement.enabled = false;
            loseUI.Score = presentsCollected;
            loseUI.MaxScore = maxPresents;
            loseUI.gameObject.SetActive(true);
        }

        public void IncrementCollectedPresents(int i)
        {
            presentsCollected += i;
            PresentCollectedEvent?.Invoke(i);
        }
    }
}
