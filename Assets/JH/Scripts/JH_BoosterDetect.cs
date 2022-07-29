using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_BossterDetect : MonoBehaviour
{
    // �̵� ����, �̵� �Ÿ�
    Rigidbody rigid;
    JH_PlayerMove player;

    Vector3 dir;
    Vector3 originPos;
    public float moveDis;
    public float boosterDis;
    public float force;
    public float angleY;
    public bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        // �θ�(Enemy)�� rigidbody ��������
        rigid = GetComponentInParent<Rigidbody>();
        // ƨ��� �� ��ġ
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �ε�����
        if (isHit)
        {
            // ���� �Ÿ� ���� �� �������� �ʹ�.
            if (Vector3.Distance(originPos, transform.position) > moveDis)
            {
                Destroy(gameObject);
                isHit = false;
            }
        }

        // 2. �ν���
        // �÷��̾ �ν��͸� ���� �ְ�, ���� ���� �Ÿ� ���̸� ���󰡰� �ʹ�.

    }

    //player�� �ε����� player�� �̵�����+�������� �̵��ϰ� �ʹ�.
    //���� �Ÿ� �̻� ���󰡸� �������� �ʹ�.
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ����� Player�̸�
        if (other.gameObject.name.Contains("Player") && !isHit)
        {
            // ���� ���� ���� ���¸� true�� �����.
            isHit = true;
            // Player�� ���� ���� ��ũ��Ʈ�� �����´�.
            player = other.gameObject.GetComponent<JH_PlayerMove>();

            if (player)
            {
                // ���� ƨ�ܳ��� ������ ���ϰ� �ʹ�.
                // �÷��̾��� �չ����� ���Ѵ�.
                dir = player.transform.forward;
                // y�� ���� �����Ѵ�.
                dir.y = angleY;
                dir.Normalize();
                // dir�������� ���� ���Ѵ�.
                rigid.AddForce(dir * 1500);
            }
        }

        // ���̶� ���̸� ���ְ� �ʹ�.
        if (other.gameObject.layer == 16)
        {
            Destroy(gameObject);
        }
    }
}
