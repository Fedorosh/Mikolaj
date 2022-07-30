using Fedorosh.Collisions.Collectables;
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
        private int maxPresents = 1;
        private int presentsCollected;

        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private WinInfo winUI;

        private AudioController audioController;

        public static PresentCollectedEvent PresentCollectedEvent = new PresentCollectedEvent();

        public int PresentsCollected => presentsCollected;
        public static AudioController AudioController => Instance.audioController;

        private void Start()
        {
            audioController = GetComponent<AudioController>();
        }

        public void ShowWinScreen()
        {
            playerMovement.enabled = false;
            winUI.Score = presentsCollected;
            winUI.MaxScore = maxPresents;
            winUI.gameObject.SetActive(true);
            audioController.PlayWinSound();
        }


        public void IncrementCollectedPresents(int i)
        {
            presentsCollected += i;
            PresentCollectedEvent?.Invoke(i);
        }
    }
}
