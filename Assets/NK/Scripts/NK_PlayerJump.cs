using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerJump : MonoBehaviour
{
    /*NK_PlayerJump playerJump;
    float jumpSpeed;

    void Start()
    {
        jumpSpeed = 30.0f;
        playerJump = this;
    }

    void Update()
    {
        if (NK_PlayerMove.Instance.isJumping)
        {
            Vector3 dir = transform.root.InverseTransformDirection(transform.root.right);
            dir.Normalize();
            transform.Rotate(dir * jumpSpeed);
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
            transform.root.localEulerAngles = Vector3.zero;
            playerJump.enabled = false;
        }
    }*/

    public TrailRenderer trailRenderer;
    public float jumpSpeed = 10.0f;
    public float jumpPower = 3;
    public bool isJumping;
    public bool isJumpBlock;
    public Vector3 dir = Vector3.zero;

    Animator anim;
    CharacterController controller;
    float jumpTime;

    public static NK_PlayerJump Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isJumping = false;
        jumpTime = 0;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            // 점프블럭 전 트레일렌더러 비활성화
            trailRenderer.enabled = false;

            anim.SetBool("IsJumping", false);
            anim.SetBool("IsSpringJumping", false);
            isJumping = false;

            if ((Input.GetButton("Jump") || isJumpBlock) && !isJumping)
            {
                if (isJumpBlock)
                {
                    anim.SetBool("IsSpringJumping", true);
                    trailRenderer.enabled = true;
                }
                else
                {
                    anim.SetBool("IsJumping", true);
                }

                isJumping = true;
            }

            if (isJumping)
            {
                Jump();
            }
        }
        controller.Move(dir * jumpPower * Time.deltaTime);
    }

    public void Jump()
    {
        float height = (jumpTime * jumpTime * (-NK_PlayerMove.Instance.gravity) / 2) + (jumpTime * jumpPower);

        dir.y = jumpSpeed + height;
        jumpTime += Time.deltaTime;

        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
        }
    }
}
