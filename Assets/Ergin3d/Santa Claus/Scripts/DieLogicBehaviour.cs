
using Fedorosh;
using Fedorosh.Dying;
using UnityEngine;

public class DieLogicBehaviour : IDieBehaviour
{
    private CharacterController characterController;

    public DieLogicBehaviour(CharacterController characterController)
    {
        this.characterController = characterController;
        DyingController.TriggerDieEvent.AddListener(Die);
    }

    public void Die(DyingObject dyingObject)
    {
        characterController.enabled = false;
        GameController.AudioController.PlayDeathSound();
    }
}
