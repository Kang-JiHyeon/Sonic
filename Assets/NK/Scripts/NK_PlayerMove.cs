using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_PlayerMove : MonoBehaviour
{
    public float speed = 10f;      // 캐릭터 움직임 스피드.
    public float jumpSpeed; // 캐릭터 점프 힘.
    public float gravity;    // 캐릭터에게 작용하는 중력.
    public bool isJumping;
    public bool isJumpBlock;
    public CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.

    Vector3 dir;                // 캐릭터의 움직이는 방향.
    float jumpPower;   //점프력
    float jumpTime;    //점프 이후 경과시간

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
        // 현재 캐릭터가 땅에 있는가?
        if (controller.isGrounded)
        {
            isJumping = false;
            // 위, 아래 움직임 셋팅. 
            dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // 카메라가 바라보는 방향을 앞방향으로 하고싶다.
            dir = Camera.main.transform.TransformDirection(dir);

            // 스피드 증가.
            dir *= speed;

            // 캐릭터 점프
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

        // 캐릭터에 중력 적용.
        dir.y -= gravity * Time.deltaTime;

        // 캐릭터 움직임.
        controller.Move(dir * Time.deltaTime);
    }

    public void Jump()
    {
        //y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
        //적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
        //변화된 높이 height를 기존 높이 _posY에 더한다.
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        dir.y = jumpSpeed + height;
        //점프시간을 증가시킨다.
        jumpTime += Time.deltaTime;

        //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
        }
    }
}