using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PlayerJump : MonoBehaviour
{
    private Transform _transform;
    private bool isJumping;
    private float posY;        //������Ʈ�� �ʱ� ����
    private float gravity;     //�߷°��ӵ�
    private float jumpPower;   //������
    private float jumpSpeed;
    private float jumpTime;    //���� ���� ����ð�

    public static JH_PlayerJump Instance;

    void Start()
    {
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

        //transform.Rotate(jumpSpeed, 0, 0);

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
