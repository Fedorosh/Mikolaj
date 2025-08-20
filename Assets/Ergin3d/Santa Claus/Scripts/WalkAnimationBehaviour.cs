using UnityEngine;

public class WalkAnimationBehaviour : IWalkBehaviour
{
    private Animator animator;
    private const string movingFloat = "Walk";

    public WalkAnimationBehaviour(Animator animator)
    { 
        this.animator = animator; 
    }

    public void Walk(float x, float z)
    {
        float magnitude = new Vector2(x, z).magnitude;
        animator.SetFloat(movingFloat, magnitude);
    }
}
