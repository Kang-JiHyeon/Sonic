using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 10.0f;
    public float jumpPower = 3;
    public float gravity = 20.0f;
    public bool isJumping;
    public CharacterController controller;
    public bool isJumpBlock;
    public Vector3 dir = Vector3.zero;

    Vector3 look = Vector3.forward;
    Vector3 camDir;
    NK_PlayerJump playerJump;
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
        /*GameObject player = transform.GetChild(0).gameObject;
        playerJump = player.GetComponent<NK_PlayerJump>();*/
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = 0;
        if (!Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal)
        {
            h = Input.GetAxis("Horizontal");
        }
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", v);

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);

        if (controller.isGrounded)
        {
            dir = Vector3.zero;

            anim.SetBool("IsJumping", false);
            anim.SetBool("IsSpringJumping", false);
            isJumping = false;

            dir = new Vector3(h, 0, v);
            dir = Camera.main.transform.TransformDirection(dir);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), Time.deltaTime * 5);

            if ((Input.GetButton("Jump") || isJumpBlock) && !isJumping)
            {
                if (isJumpBlock)
                {
                    anim.SetBool("IsSpringJumping", true);
                }
                else
                {
                    anim.SetBool("IsJumping", true);
                }

                isJumping = true;
            }

            if (isJumping)
            {
                //playerJump.enabled = true;
                //dir.y = jumpPower;
                Jump();
            }
        }

        if (dir != Vector3.zero)
        {
            look = dir;
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
    }

    public void Jump()
    {
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        dir.y = jumpSpeed + height;
        jumpTime += Time.deltaTime;

        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
        }
    }
}
