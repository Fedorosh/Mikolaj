using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float speed = 12f;
    public float rotateSpeed = 200f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    private const string movingBool = "isMoving";
    private const string jumpingTrigger = "Jump";

    [SerializeField] private Text debugText;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && isJumping) isJumping = false;


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Mouse1)) z = 1f;

        if(animator != null)
        animator.SetBool(movingBool, z != 0f);

        Vector3 move = transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * x * rotateSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger(jumpingTrigger);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if(Input.GetButtonDown("Jump") && !isGrounded && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger(jumpingTrigger);
            isJumping = true;
        }
    }
}
