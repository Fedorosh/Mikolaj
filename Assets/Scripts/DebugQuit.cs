using UnityEngine;

namespace Fedorosh.Debug
{
    public class DebugQuit : DebugAction
    {
        public override void OnButtonClicked()
        {
            Application.Quit();
        }
    }
}
