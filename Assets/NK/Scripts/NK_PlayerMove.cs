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

    public static NK_PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isJumping = false;
        transform.localEulerAngles = Vector3.zero;
        controller = GetComponent<CharacterController>();
        GameObject player = transform.GetChild(0).gameObject;
        playerJump = player.GetComponent<NK_PlayerJump>();
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);

        if (controller.isGrounded)
        {
            dir = Vector3.zero;

            isJumping = false;

            dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            dir = Camera.main.transform.TransformDirection(dir);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), Time.deltaTime * 5);

            if ((Input.GetButton("Jump") || isJumpBlock) && !isJumping)
            {
                isJumping = true;
            }

            if (isJumping)
            {
                playerJump.enabled = true;
                dir.y = jumpPower;
            }
        }

        if (dir != Vector3.zero)
        {
            look = dir;
        }

        //speed += Time.deltaTime;

        dir.y -= gravity * Time.deltaTime;

        controller.Move(dir * speed * Time.deltaTime);
    }
}
