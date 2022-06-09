using Fedorosh.Dying;
using Fedorosh.Respawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private Animator animator;

        public float speed = 12f;
        public float rotateSpeed = 200f;
        public float gravity = -9.81f;
        public float jumpHeight = 3.0f;
        public float secondJumpHeight = 1.5f;

        private const string movingBool = "isMoving";
        private const string jumpingTrigger = "Jump";
        private const string dyingTrigger = "Die";
        private const string respawnTrigger = "Respawn";

        [SerializeField] private Text debugText;
        [SerializeField] Joystick joystick;

        [SerializeField] private PlatformSettingsObject androidSettings;
        [SerializeField] private PlatformSettingsObject pcSettings;

        private InputMiddleware input;

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
            DyingController.TriggerDieEvent.AddListener(Die);
            RespawningController.TriggerRespawnEvent.AddListener(Respawn);
            input = new InputMiddleware(joystick, GetComponent<DyingObject>());
#if !UNITY_ANDROID
            Cursor.lockState = CursorLockMode.Locked;
            rotateSpeed = pcSettings.turnSensitivity;
            speed = pcSettings.walkSpeed;
            jumpHeight = pcSettings.jumpHeight;
#endif
#if UNITY_ANDROID
        androidUI.SetActive(true);
        rotateSpeed = androidSettings.turnSensitivity;
        speed = androidSettings.walkSpeed;
        jumpHeight = androidSettings.jumpHeight;
#endif
        }

        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && isJumping) isJumping = false;


            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

#if !UNITY_ANDROID
            float z = input.GetAxis("Vertical");
            float x = input.GetAxis("Horizontal");
#else
        float z = input.GetVerticalJoystick();
        float x = input.GetHorizontalJoystick();
#endif

            if (input.GetKey(KeyCode.Mouse1)) z = 1f;

            if (animator != null)
                animator.SetBool(movingBool, z != 0f);

            Vector3 move = transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * x * rotateSpeed * Time.deltaTime);
#if !UNITY_ANDROID
            if (input.GetButtonDown("Jump") && isGrounded)
#else
        if(input.GetTouch() && isGrounded)
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
#if !UNITY_ANDROID
            if (input.GetButtonDown("Jump") && !isGrounded && !isJumping)
#else
        if (input.GetTouch() && !isGrounded && !isJumping)
#endif
            {
                velocity.y = Mathf.Sqrt(secondJumpHeight * -2f * gravity);
                animator.SetTrigger(jumpingTrigger);
                isJumping = true;
            }
        }

        private void Die(DyingObject dyingObject)
        {
            animator.SetTrigger(dyingTrigger);
            dyingObject.CharacterController.enabled = false;
        }
        private void Respawn(DyingObject dyingObject)
        {
            animator.SetTrigger(respawnTrigger);
            dyingObject.CharacterController.enabled = true;
        }
    }
}

