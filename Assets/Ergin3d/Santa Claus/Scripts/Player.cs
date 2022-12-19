using Fedorosh.Dying;
using Fedorosh.Respawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fedorosh
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        private CharacterController controller;
        private Animator animator;

        private IWalkBehaviour[] walkBehaviours;

        public float speed = 12f;
        public float rotateSpeed = 400f;
        public float gravity = -9.81f;
        public float jumpHeight = 3.0f;
        public float secondJumpHeight = 1.5f;

        private const string jumpingTrigger = "Jump";
        private const string dyingTrigger = "Die";
        private const string respawnTrigger = "Respawn";

        [SerializeField] private float turnSmoothTime = 0.1f;
        float turnSmoothVelocity;
        [SerializeField] Transform cam;

        [SerializeField] private Text debugText;
        [SerializeField] Joystick joystick;

        [SerializeField] private PlatformSettingsObject androidSettings;
        [SerializeField] private PlatformSettingsObject pcSettings;

        [SerializeField] private Button jumpButton;

        public CharacterController GetCharacterController => controller;

        public static InputMiddleware input;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        [SerializeField] private GameObject androidUI;

        Vector3 velocity;
        bool isGrounded;
        bool isJumping = false;
#if UNITY_ANDROID
        bool jumpButtonClicked = false;
#endif

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();

            walkBehaviours = new IWalkBehaviour[2]
            {
                new StrafeWalkBehaviour(controller, turnSmoothTime, speed),
                new WalkAnimationBehaviour(animator)
            };

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
        jumpButton.onClick.AddListener(AndroidJump);
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
#if !UNITY_ANDROID
            if (input.GetKey(KeyCode.Mouse1)) z = 1f;
#endif
            foreach(var w in walkBehaviours)
                w.Walk(x, z);

            //Vector3 move = new Vector3(x, 0f, z).normalized;
            //float magnitude = new Vector2(x, z).magnitude;



            //if (move.magnitude >= 0.1f)
            //{
            //    float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
            //        ref turnSmoothVelocity, turnSmoothTime);

            //    transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //    controller.Move(moveDir.normalized * magnitude * speed * Time.deltaTime);
            //}


#if !UNITY_ANDROID
            if (input.GetButtonDown("Jump") && isGrounded)
#else
            if (jumpButtonClicked && isGrounded)
#endif
            {
#if UNITY_ANDROID
                jumpButtonClicked = false;
#endif
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * -9.82f);
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
            if (jumpButtonClicked && !isGrounded && !isJumping)
#endif
            {
#if UNITY_ANDROID
                jumpButtonClicked = false;
#endif
                velocity.y = Mathf.Sqrt(secondJumpHeight * -2f * -9.82f);
                animator.SetTrigger(jumpingTrigger);
                isJumping = true;
            }
#if UNITY_ANDROID
            else jumpButtonClicked = false;
#endif
        }
#if UNITY_ANDROID
        private void AndroidJump()
        {
            if (input.CanUseJump)
            {
                jumpButtonClicked = true;

            }
        }
        private void JumpDelay()
        {

        }
#endif

        private void Die(DyingObject dyingObject)
        {
            animator.SetTrigger(dyingTrigger);
            dyingObject.CharacterController.enabled = false;
            GameController.AudioController.PlayDeathSound();
        }
        private void Respawn(DyingObject dyingObject)
        {
            animator.SetTrigger(respawnTrigger);
            dyingObject.CharacterController.enabled = true;
        }
    }
}

