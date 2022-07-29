using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ű�� ������ ���� �밢������ �����Ÿ� ���󰡰� �ʹ�.
// �ʿ�Ӽ� : �̵� ����, �̵� �Ÿ�, �ӵ�, ����
public class JH_Enemy : MonoBehaviour
{
    // �̵� ����, �̵� �Ÿ�
    Rigidbody rigid;
    JH_PlayerMove player;
    Vector3 dir;
    Vector3 originPos;
    public float moveDis;
    public float force;
    public float angleY;
    public bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        // TEST
        rigid = GetComponent<Rigidbody>();
        // ƨ��� �� ��ġ
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ������
        if (isHit)
        {
            // Player�� ���� ���� ��ũ��Ʈ�� �����´�.
            player = GameObject.Find("Player").GetComponent<JH_PlayerMove>();
            // ���� ƨ�ܳ��� ������ ���Ѵ�.
            dir = new Vector3(player.dir.x, angleY, player.dir.z);
            dir.Normalize();

            // ���� rigidbody������Ʈ
            rigid.AddForce(dir * force, ForceMode.Impulse);

            if (Vector3.Distance(originPos, transform.position) > moveDis)
            {
                Destroy(gameObject);
                isHit = false;
            }

        }
    }

    // player�� �ε����� player�� �̵�����+�������� �̵��ϰ� �ʹ�.
    // ���� �Ÿ� �̻� ���󰡸� �������� �ʹ�.
    private void OnCollisionEnter(Collision collision)
    {
        // �ε��� ����� Player�̸�
        if (collision.gameObject.name.Contains("Player"))
        {
            // ���� ���� ���� ���¸� true�� �����.
            isHit = true;
        }
    }
}
