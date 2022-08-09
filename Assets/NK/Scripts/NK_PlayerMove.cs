using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 10f;      // ĳ���� ������ ���ǵ�.
    public float jumpSpeed; // ĳ���� ���� ��.
    public float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.
    public bool isJumping;
    public bool isJumpBlock;
    public CharacterController controller; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.

    Vector3 dir;                // ĳ������ �����̴� ����.
    float jumpPower;   //������
    float jumpTime;    //���� ���� ����ð�

    public static NK_PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        jumpSpeed = 10.0f;
        jumpPower = 30.0f;
        jumpTime = 0.0f;
        gravity = 20.0f;
        isJumping = false;
        dir = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // ���� ĳ���Ͱ� ���� �ִ°�?
        if (controller.isGrounded)
        {
            isJumping = false;
            // ��, �Ʒ� ������ ����. 
            dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // ī�޶� �ٶ󺸴� ������ �չ������� �ϰ�ʹ�.
            dir = Camera.main.transform.TransformDirection(dir);

            // ���ǵ� ����.
            dir *= speed;

            // ĳ���� ����
            if (Input.GetButton("Jump") && !isJumping)
            {
                isJumping = true;
            }

            if (isJumping)
            {
                Jump();
            }
        }

        transform.rotation = Quaternion.LookRotation(dir);

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