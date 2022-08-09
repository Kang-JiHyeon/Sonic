using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{

    public float speed = 10f;
    public float jumpSpeed;
    public float jumpPower;
    public float gravity;
    public bool isJumping;
    public CharacterController controller;
    public bool isJumpBlock;

    Vector3 look = Vector3.forward;
    public Vector3 dir = Vector3.zero;
    Vector3 camDir;
/*    float jumpTime;    //���� ���� �����ð�*/

    public static NK_PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        jumpSpeed = 10.0f;
        jumpPower = 15;
        //jumpTime = 0.0f;
        gravity = 20.0f;
        isJumping = false;
        controller = GetComponent<CharacterController>();
        transform.localEulerAngles = Vector3.zero;
    }

    void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);

        if (controller.isGrounded)
        {
            dir = Vector3.zero;
            isJumping = false;

            dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            dir = Camera.main.transform.TransformDirection(dir);

            dir *= speed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), Time.deltaTime * 5);

            if ((Input.GetButton("Jump") || isJumpBlock) && !isJumping)
            {
                isJumping = true;
            }

            if (isJumping)
            {
                dir.y = jumpPower;
            }
        }

        if (dir != Vector3.zero)
        {
            look = dir;
        }

        dir.y -= gravity * Time.deltaTime;

        controller.Move(dir * Time.deltaTime);
    }

/*    public void Jump()
    {
        //y=-a*x+b���� (a: �߷°��ӵ�, b: �ʱ� �����ӵ�)
        //�����Ͽ� y = (-a/2)*x*x + (b*x) ������ ���´�.(x: �����ð�, y: ������Ʈ�� ����)
        //��ȭ�� ���� height�� ���� ���� _posY�� ���Ѵ�.
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        dir.y = jumpSpeed + height;
        //�����ð��� ������Ų��.
        jumpTime += Time.deltaTime;

        //ó���� ���� ���� �� ���� ������ => ������ ���·� �����Ѵ�.
        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
        }
    }*/
}