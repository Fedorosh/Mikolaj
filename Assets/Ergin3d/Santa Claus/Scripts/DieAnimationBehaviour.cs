using Fedorosh.Dying;
using UnityEngine;

public class DieAnimationBehaviour : IDieBehaviour
{
    private Animator animator;
    private const string dyingTrigger = "Die";

    public DieAnimationBehaviour(Animator animator) 
    { 
        this.animator = animator;
        DyingController.TriggerDieEvent.AddListener(Die);
    }

    public void Die(DyingObject dyingObject)
    {
        animator.SetTrigger(dyingTrigger);
    }
}
