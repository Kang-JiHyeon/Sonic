using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerJump : MonoBehaviour
{
    private Transform _transform;
    private bool _isJumping;
    private float _posY;        //������Ʈ�� �ʱ� ����
    private float _gravity;     //�߷°��ӵ�
    private float _jumpPower;   //������
    private float _jumpTime;    //���� ���� ����ð�

    void Start()
    {
        _transform = transform;
        _isJumping = false;
        _posY = transform.position.y;
        _gravity = 9.8f;
        _jumpPower = 15.0f;
        _jumpTime = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            _posY = _transform.position.y;
        }

        if (_isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        //y=-a*x+b���� (a: �߷°��ӵ�, b: �ʱ� �����ӵ�)
        //�����Ͽ� y = (-a/2)*x*x + (b*x) ������ ��´�.(x: �����ð�, y: ������Ʈ�� ����)
        //��ȭ�� ���� height�� ���� ���� _posY�� ���Ѵ�.
        float height = (_jumpTime * _jumpTime * (-_gravity) / 2) + (_jumpTime * _jumpPower);
        _transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
        //�����ð��� ������Ų��.
        _jumpTime += Time.deltaTime;

        //ó���� ���� ���� �� ���� ������ => ������ ���·� �����Ѵ�.
        if (height < 0.0f)
        {
            _isJumping = false;
            _jumpTime = 0.0f;
            _transform.position = new Vector3(_transform.position.x, _posY, _transform.position.z);
        }
    }
}
