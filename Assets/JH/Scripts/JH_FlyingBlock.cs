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
    public Transform[] landPos;
    int index = 0;
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
            player.transform.position = Vector3.Lerp(player.position, landPos[index].position, Time.deltaTime);

            if(Vector3.Distance(player.position, landPos[index].position) < 0.1f)
            {
                //NK_PlayerMove.Instance.gravity = originGravity;
                player.position = landPos[index].position;
                NK_PlayerMove.Instance.enabled = false;
                isFlying = false;
                index = (index + 1) % landPos.Length;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            //NK_PlayerMove.Instance.speed = originMoveSpeed * flyingBlockSpeed;
            
            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = true;

            isFlying = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = false;
            NK_PlayerMove.Instance.enabled = false;
        }

    }
}
