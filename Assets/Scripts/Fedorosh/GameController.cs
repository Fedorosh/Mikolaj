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

        public static PresentCollectedEvent PresentCollectedEvent = new PresentCollectedEvent();

        public int PresentsCollected => presentsCollected;

        public void IncrementCollectedPresents(int i)
        {
            presentsCollected += i;
            PresentCollectedEvent?.Invoke(i);
        }
    }
}
