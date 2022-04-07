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
    [SerializeField] private Joystick joystick;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private GameObject androidUI;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
#if !UNITY_ANDROID || UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        androidUI.SetActive(true);
#endif
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && isJumping) isJumping = false;


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

#if !UNITY_ANDROID || UNITY_EDITOR
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
#else
        float z = joystick.Vertical;
        float x = joystick.Horizontal;
#endif

        if (Input.GetKey(KeyCode.Mouse1)) z = 1f;

        if(animator != null)
        animator.SetBool(movingBool, z != 0f);

        Vector3 move = transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * x * rotateSpeed * Time.deltaTime);
#if UNITY_EDITOR || !UNITY_ANDROID
        if(Input.GetButtonDown("Jump") && isGrounded)
#else
        if(GetTouch() && isGrounded)
#endif
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger(jumpingTrigger);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void LateUpdate()
    {
#if UNITY_EDITOR || !UNITY_ANDROID
        if(Input.GetButtonDown("Jump") && !isGrounded && !isJumping)
#else
        if (GetTouch() && !isGrounded && !isJumping)
#endif
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger(jumpingTrigger);
            isJumping = true;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private bool GetTouch()
    {
        if(Input.touchCount == 0) return false;

        Touch touch = Input.GetTouch(Input.touchCount - 1);

        Vector2 touchPos = touch.position;
        int x = Screen.width / 2;
        return touchPos.x >= x && touch.phase == TouchPhase.Ended;
    }
#endif
}
