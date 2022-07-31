using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �Ϲ�
// �÷��̾�� �ε����� �÷��̾� �̵� ���� + �������� �����Ÿ� ���󰡰� �ʹ�.
// �ʿ�Ӽ� : �̵� ����, �̵� �Ÿ�, �ӵ�, ����

// 2. �ν���
// �÷��̾ �ν��͸� ���� �ְ�, ���� ���� �Ÿ� ���̸� ���󰡰� �ʹ�.


// 3. ��
// ���̶� ������ �������� �ʹ�.
public class JH_Enemy : MonoBehaviour
{
    // �̵� ����, �̵� �Ÿ�
    Rigidbody rigid;
    public GameObject target;

    
    Vector3 dir;
    Vector3 originPos;
    JH_PlayerMove player;

    public float moveDis;
    public float boosterDis;
    public float force;
    public float angleY;
    public bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        // ƨ��� �� ��ġ
        originPos = transform.position;
        // Player�� ���� ���� ��ũ��Ʈ�� �����´�.
        player = target.GetComponent<JH_PlayerMove>();
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
        // NK_Booster�� isBooster ��ü
        if (Vector3.Distance(transform.position, target.transform.position) < boosterDis && player.isBooster)
        {
            Hit();
        }
    }
    private void Hit()
    {
        // ���� ���� ���� ���¸� true�� �����.
        isHit = true;

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
    //player�� �ε����� player�� �̵�����+�������� �̵��ϰ� �ʹ�.
    //���� �Ÿ� �̻� ���󰡸� �������� �ʹ�.
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ����� Player�̸�
        if (other.gameObject.name.Contains("Player") && !isHit)
        {
            // ���� ���� ���� ���¸� true�� �����.
            Hit();
        }

        // ���̶� ���̸� ���ְ� �ʹ�.
        if(other.gameObject.layer == 16)
        {
            Destroy(gameObject);
        }
    }
}
