
using Fedorosh.Dying;
using Fedorosh.Respawning;
using UnityEngine;

public class RespawnAnimationBehaviour : IRespawnBehaviour
{
    private Animator animator;
    private const string respawnTrigger = "Respawn";

    public RespawnAnimationBehaviour(Animator animator)
    {
        this.animator = animator;
        RespawningController.TriggerRespawnEvent.AddListener(Respawn);
    }

    public void Respawn(DyingObject dyingObject)
    {
        animator.SetTrigger(respawnTrigger);
    }
}
