using Fedorosh.Collisions.Collectables;
using Fedorosh.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedorosh
{
    public class GameController : MonoBehaviourSingleton<GameController>
    {
        private int maxPresents;
        private int presentsCollected;

        private AudioController audioController;

        public static PresentCollectedEvent PresentCollectedEvent = new PresentCollectedEvent();

        public int PresentsCollected => presentsCollected;
        public static AudioController AudioController => Instance.audioController;

        private void Start()
        {
            audioController = GetComponent<AudioController>();
        }

        public void IncrementCollectedPresents(int i)
        {
            presentsCollected += i;
            PresentCollectedEvent?.Invoke(i);
        }
    }
}
