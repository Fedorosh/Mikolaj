
using Fedorosh.Dying;
using Fedorosh.Respawning;
using UnityEngine;

public class RespawnLogicBehaviour : IRespawnBehaviour
{
    private CharacterController characterController;

    public RespawnLogicBehaviour(CharacterController characterController)
    {
        this.characterController = characterController;
        RespawningController.TriggerRespawnEvent.AddListener(Respawn);
    }

    public void Respawn(DyingObject dyingObject)
    {
        characterController.enabled = true;
    }
}
