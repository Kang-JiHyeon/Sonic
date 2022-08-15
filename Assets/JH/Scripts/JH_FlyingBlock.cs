using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� ����� ������ �÷��̾��� ���������� ���� �ְ� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�, �÷��̾��� yVelocity
public class JH_FlyingBlock : MonoBehaviour
{
    // ���� ��
    public float originJumpPower;
    public float flyingJumpPower = 3f;

    // ������ �ӵ�
    public float originMoveSpeed;
    public float flyingBlockSpeed = 2;

    // �߷�
    public float originGravity;
    public float flyingGravity = 0.1f;

    Transform player;
    public Transform randPos;
    // �ö���?
    bool isFlying = false;
    private void Start()
    {
        originJumpPower = NK_PlayerMove.Instance.jumpPower;
        originMoveSpeed = NK_PlayerMove.Instance.speed;
        originGravity = NK_PlayerMove.Instance.gravity;

        player = NK_PlayerMove.Instance.gameObject.transform;
    }


    // �ö��� ���� ������ RandPosition���� �̵��ϰ� �ʹ�.
    private void Update()
    {
        if (isFlying)
        {
            NK_PlayerMove.Instance.gravity = 0f;
            player.transform.position = Vector3.Lerp(player.position, randPos.position, Time.deltaTime * 20f);

            if(Vector3.Distance(player.position, randPos.position) < 0.1f)
            {
                NK_PlayerMove.Instance.gravity = originGravity;
                player.position = randPos.position;
                isFlying = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            //NK_PlayerMove.Instance.speed = originMoveSpeed * flyingBlockSpeed;
            

            Camera.main.gameObject.GetComponent<JH_Camera>().isVertical = false;
            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = true;

            isFlying = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = false;
        }

    }
}
