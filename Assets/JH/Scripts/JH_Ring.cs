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
    GameObject target;
    NK_Booster player;
    public float speed = 10f;
    public float boosterDis = 20f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        // Player�� ��ũ��Ʈ�� �����´�.
        player = target.GetComponent<NK_Booster>();
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾�� ���� �Ÿ� �ȿ� �ְ�, �÷��̾ �ν��� �����̸� �÷��̾� ������ �̵��ϰ� �ʹ�.
        if (Vector3.Distance(transform.position, target.transform.position) < boosterDis && player.isBooster)
        {
            // ** �Ҵ� �ν��� �ӵ� ���� ������ �ӵ� �����ϱ�!! **
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

            if(Vector3.Distance(transform.position, target.transform.position) < 1f)
            {
                // ���� ����
                JH_Score.Instance.SCORE++;
                // ����
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� ������ ������ +1 �ϰ� ������� �ʹ�.
        if (other.gameObject.name.Contains("Player") && !player.isBooster)
        {
            // ���� ����
            JH_Score.Instance.SCORE++;
            // ����
            Destroy(gameObject);
        }
    }
}
