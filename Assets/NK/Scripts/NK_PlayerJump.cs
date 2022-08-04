using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerJump : MonoBehaviour
{
    CharacterController cc;
    Transform _transform;
    public bool isJumping;
    float posY;        //������Ʈ�� �ʱ� ����
    float gravity;     //�߷°��ӵ�
    float jumpPower;   //������
    float jumpSpeed;
    float jumpTime;    //���� ���� ����ð�

    public static NK_PlayerJump Instance;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        Instance = this;
        _transform = transform;
        isJumping = false;
        posY = transform.position.y;
        gravity = 20f;
        jumpSpeed = 10.0f;
        jumpPower = 15.0f;
        jumpTime = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            posY = _transform.position.y;
        }

        if (isJumping)
        {
            Jump();
        }
    }

    public void Jump()
    {
        //y=-a*x+b���� (a: �߷°��ӵ�, b: �ʱ� �����ӵ�)
        //�����Ͽ� y = (-a/2)*x*x + (b*x) ������ ��´�.(x: �����ð�, y: ������Ʈ�� ����)
        //��ȭ�� ���� height�� ���� ���� _posY�� ���Ѵ�.
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        _transform.position = new Vector3(_transform.position.x, posY + height, _transform.position.z);
        //�����ð��� ������Ų��.
        jumpTime += Time.deltaTime;

        transform.Rotate(jumpSpeed, 0, 0);

        //ó���� ���� ���� �� ���� ������ => ������ ���·� �����Ѵ�.
        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;

            _transform.position = new Vector3(_transform.position.x, posY, _transform.position.z);
            _transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
