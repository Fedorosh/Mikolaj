using Fedorosh.HPFolder;
using UnityEngine;

public class StrafeMovementBehaviour : IMovementBehaviour
{
    private CharacterController characterController;
    private float turnSmoothVelocity;
    private float turnSmoothTime;
    private float speed;
    private Transform transform;

    public StrafeMovementBehaviour(CharacterController characterController, float turnSmoothTime, float speed)
    { 
        this.characterController = characterController; 
        this.turnSmoothTime = turnSmoothTime;
        this.transform = characterController.transform;
        this.speed = speed;
    }

    public void Move(float x, float z)
    {
        //some moving
        Vector3 move = new Vector3(x, 0f, z).normalized;
        float magnitude = new Vector2(x, z).magnitude;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDir.normalized * magnitude * speed * Time.deltaTime);
        }
    }
}
