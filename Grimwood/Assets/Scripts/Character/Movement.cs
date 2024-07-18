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
    public float jumpSpeed;

    [SerializeField]
    public float jumpButtonGracePeriod;

    [SerializeField]
    public float jumpHorizontalSpeed;

    private float ySpeed;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private Vector3 movementDirection;
    private float inputMagnitude;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleJumping();
    }

    public void AnimateCharacter(float forward, float strafe)
    {
        anim.SetFloat(animStrings.forward, forward);
        anim.SetFloat(animStrings.strafe, strafe);
    }

    public void SprintCharacter(bool isSprinting)
    {
        anim.SetBool(animStrings.sprint, isSprinting);
    }

    public void JumpCharacter()
    {
        if (cc.isGrounded)
        {
            jumpButtonPressedTime = Time.time;
        }
    }

    public void HandleJumping()
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

        Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
        velocity.y = ySpeed;

        cc.Move(velocity * Time.deltaTime);
    }

    public void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = anim.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;
            cc.Move(velocity);
        }
    }

}
