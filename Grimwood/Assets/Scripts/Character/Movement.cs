using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public CharacterController cc;
    public Animator anim;

    [System.Serializable]
    public class AnimationStrings
    {
        public string forward = "forward";
        public string strafe = "strafe";
        public string sprint = "sprint";
        public string isGrounded = "isGrounded";
        public string isJumping = "isJumping";
        public string isFalling = "isFalling";
        public string isMoving = "isMoving";
    }

    [SerializeField]
    public AnimationStrings animStrings;

    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private float sprintSpeed = 4.0f;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float jumpButtonGracePeriod;
    [SerializeField]
    private float rotationSpeed = 700.0f;

    private float ySpeed;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private Vector3 movementDirection;
    private float inputMagnitude;
    private bool isSprinting;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        ApplyMovement();
    }

    public void AnimateCharacter(float forward, float strafe)
    {
        anim.SetFloat(animStrings.forward, forward);
        anim.SetFloat(animStrings.strafe, strafe);
    }

    public void SprintCharacter(bool sprint)
    {
        isSprinting = sprint;
        anim.SetBool(animStrings.sprint, sprint);
    }

    public void JumpCharacter()
    {
        if (cc.isGrounded)
        {
            jumpButtonPressedTime = Time.time;
        }
    }

    private void HandleMovement()
    {
        float forward = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");
        movementDirection = new Vector3(strafe, 0, forward).normalized;
        movementDirection = transform.TransformDirection(movementDirection); // Yerel koordinatlarý dünya koordinatlarýna çevir

        inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (movementDirection != Vector3.zero)
        {
            anim.SetBool(animStrings.isMoving, true);
        }
        else
        {
            anim.SetBool(animStrings.isMoving, false);
        }
    }

    private void HandleJumping()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded)
        {
            lastGroundedTime = Time.time;
            anim.SetBool(animStrings.isGrounded, true);
            anim.SetBool(animStrings.isJumping, false);
            anim.SetBool(animStrings.isFalling, false);
            isJumping = false;
        }
        else
        {
            anim.SetBool(animStrings.isGrounded, false);
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                anim.SetBool(animStrings.isJumping, true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            if (isJumping && ySpeed < 0)
            {
                anim.SetBool(animStrings.isFalling, true);
            }
        }
    }

    private void ApplyMovement()
    {
        Vector3 velocity = movementDirection * inputMagnitude * (isSprinting ? sprintSpeed : walkSpeed);
        velocity.y = ySpeed;

        cc.Move(velocity * Time.deltaTime);
    }

    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = anim.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;
            cc.Move(velocity);
        }
    }
}
