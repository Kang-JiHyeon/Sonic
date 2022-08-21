using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 10.0f;
    public float jumpPower = 3;
    public float gravity = 10f;
    public bool isShuckShuck;
    public bool isJumping;
    public bool isJumpBlock;
    public TrailRenderer trailRenderer;
    public Vector3 dir = Vector3.zero;

    Vector3 look = Vector3.forward;
    CharacterController controller;
    Animator anim;
    float jumpTime;

    public static NK_PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isJumping = false;
        jumpTime = 0;
        transform.localEulerAngles = Vector3.zero;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();

        if (transform.position.y < -100)
        {
            //GameManager.gameManager.m_state = GameManager.GameState.GameOver;
        }
    }

    private void Move()
    {
        if (NK_Attack.Instance.isAttack || JH_Bezier.Instance.isFlying)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", v);

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);

        if (controller.isGrounded)
        {
            dir = Vector3.zero;

            trailRenderer.enabled = false;

            anim.SetBool("IsJumping", false);
            anim.SetBool("IsSpringJumping", false);
            isJumping = false;

            CheckDirection(h, v);

            dir = Camera.main.transform.TransformDirection(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), Time.deltaTime * 5);

            CheckJumping();

            if (isJumping)
                Jump();

            if (NK_Attack.Instance.isAiming)
            {
                look = NK_Attack.Instance.dir;
            }

            if (dir != Vector3.zero)
            {
                look = dir;
            }
        }


        //speed += Time.deltaTime;

        dir.y -= gravity * Time.deltaTime;

        if (!isJumping)
        {
            controller.Move(dir * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(dir * jumpPower * Time.deltaTime);
        }

        if (isShuckShuck)
            NK_ShuckShuck.Instance.ShuckShuck();
    }

    private void CheckDirection(float h, float v)
    {
        if (Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal)
            dir = new Vector3(v, 0, 0);
        else if (isShuckShuck)
            dir = new Vector3(0, 0, v);
        else
            dir = new Vector3(h, 0, v);
    }

    private void CheckJumping()
    {
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
    }

    public void Jump()
    {
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);

        dir.y = jumpSpeed + height;
        dir += transform.forward * 3;
        jumpTime += Time.deltaTime;

        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
        }
    }
}
