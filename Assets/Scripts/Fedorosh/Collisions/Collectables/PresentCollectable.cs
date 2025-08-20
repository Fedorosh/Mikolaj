using Fedorosh.Dying;

namespace Fedorosh.Collisions.Collectables
{
    public class PresentCollectable : Collectable
    {
        protected override void OnCollided(DyingObject collision)
        {
            base.OnCollided(collision);
            GameController.Instance.IncrementCollectedPresents(1);
        }
    }
}
