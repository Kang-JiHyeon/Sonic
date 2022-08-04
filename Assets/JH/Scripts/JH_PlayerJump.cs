using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_PlayerJump : MonoBehaviour
{
    private Transform _transform;
    private bool isJumping;
    private float posY;        //오브젝트의 초기 높이
    private float gravity;     //중력가속도
    private float jumpPower;   //점프력
    private float jumpSpeed;
    private float jumpTime;    //점프 이후 경과시간

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
        //y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
        //적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
        //변화된 높이 height를 기존 높이 _posY에 더한다.
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        _transform.position = new Vector3(_transform.position.x, posY + height, _transform.position.z);
        //점프시간을 증가시킨다.
        jumpTime += Time.deltaTime;

        //transform.Rotate(jumpSpeed, 0, 0);

        //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
            _transform.position = new Vector3(_transform.position.x, posY, _transform.position.z);
            _transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
