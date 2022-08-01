using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �Ϲ�
// �÷��̾�� ���̸� ������� �ϰ� �ʹ�.

// 2. �ν���
// �÷��̾�� ���� �Ÿ� �ȿ� �ְ�, �÷��̾ �ν��� �����̸� �÷��̾� ������ �̵��ϰ� �ʹ�.

// 3. ����
// ���� �÷��̾�� ������ +1
public class JH_Ring : MonoBehaviour
{
    public GameObject target;
    Rigidbody rigid;
    JH_PlayerMove player;

    float boosterDis = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        // Player�� ��ũ��Ʈ�� �����´�.
        player = target.GetComponent<JH_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Vector3.Distance(transform.position, target.transform.position));
        // �÷��̾�� ���� �Ÿ� �ȿ� �ְ�, �÷��̾ �ν��� �����̸� �÷��̾� ������ �̵��ϰ� �ʹ�.
        if (Vector3.Distance(transform.position, target.transform.position) < boosterDis && player.isBooster)
        {
            // ** �Ҵ� �ν��� �ӵ� ���� ������ �ӵ� �����ϱ�!! **
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� ������ ������ +1 �ϰ� ������� �ʹ�.
        if (other.gameObject.name.Contains("Player"))
        {

            // ���� ����
            JH_Score.Instance.SCORE++;
            // ����
            Destroy(gameObject);
        }
    }
}
