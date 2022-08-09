using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 10f;   // ĳ���� ������ ���ǵ�.
    public float jumpSpeed;     // ĳ���� ���� ��.
    public float gravity;       // ĳ���Ϳ��� �ۿ��ϴ� �߷�.
    public bool isJumping;
    public CharacterController controller;  // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    public bool isJumpBlock;        // ���� ��� Ʈ����

    public Vector3 dir;        // ĳ������ �����̴� ����.
    float jumpPower;    //������
    float jumpTime;     //���� ���� ����ð�

    public static NK_PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        jumpSpeed = 15.0f;
        jumpPower = 10.0f;
        jumpTime = 0.0f;
        gravity = 20.0f;
        isJumping = false;
        isJumpBlock = false;
        dir = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ���� ĳ���Ͱ� ���� �ִ°�?
        if (controller.isGrounded)
        {
            isJumping = false;
            // ��, �Ʒ� ������ ����. 
            dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            dir.Normalize();
            transform.rotation = Quaternion.LookRotation(dir);

            // ���ǵ� ����.
            dir *= speed;

            // ĳ���� ����
            if ((Input.GetButton("Jump") || isJumpBlock) && !isJumping)
            {
                isJumping = true;
            }

            if (isJumping)
            {
                Jump();
            }
        }

        // ĳ���Ϳ� �߷� ����.
        dir.y -= gravity * Time.deltaTime;

        // ĳ���� ������.
        controller.Move(dir * Time.deltaTime);
    }

    public void Jump()
    {
        //y=-a*x+b���� (a: �߷°��ӵ�, b: �ʱ� �����ӵ�)
        //�����Ͽ� y = (-a/2)*x*x + (b*x) ������ ��´�.(x: �����ð�, y: ������Ʈ�� ����)
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
    }
}
